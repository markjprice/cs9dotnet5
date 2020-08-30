using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Piranha;
using Piranha.AttributeBuilder;
using Piranha.AspNetCore.Identity.SQLite;
using Piranha.Data.EF.SQLite;
using Piranha.Manager.Editor;
using System.IO;

namespace NorthwindCms
{
  public class Startup
  {
    private readonly IConfiguration _config;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="configuration">The current configuration</param>
    public Startup(IConfiguration configuration)
    {
      _config = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      // Service setup
      services.AddPiranha(options =>
      {
        options.AddRazorRuntimeCompilation = true;

        options.UseFileStorage(naming: Piranha.Local.FileStorageNaming.UniqueFolderNames);
        options.UseImageSharp();
        options.UseManager();
        options.UseTinyMCE();
        options.UseMemoryCache();
        options.UseEF<SQLiteDb>(db =>
                  db.UseSqlite(_config.GetConnectionString("piranha")));
        options.UseIdentityWithSeed<IdentitySQLiteDb>(db =>
                  db.UseSqlite(_config.GetConnectionString("piranha")));
      });

      string databasePath = Path.Combine("..", "Northwind.db");
      services.AddDbContext<Packt.Shared.Northwind>(options =>
        options.UseSqlite($"Data Source={databasePath}"));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApi api)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // Initialize Piranha
      App.Init(api);

      // register GIFs as a media type
      App.MediaTypes.Images.Add(".gif", "image/gif");

      // Build content types
      new ContentTypeBuilder(api)
          .AddAssembly(typeof(Startup).Assembly)
          .Build()
          .DeleteOrphans();

      // Configure Tiny MCE
      EditorConfig.FromFile("editorconfig.json");

      // Middleware setup
      app.UsePiranha(options =>
      {
        options.UseManager();
        options.UseTinyMCE();
        options.UseIdentity();
      });
    }
  }
}