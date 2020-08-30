using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore; 
using Packt.Shared;
using System;
using System.IO;
using System.Threading.Tasks;
using static System.Console;

namespace NorthwindWeb
{
  public class Startup
  {
    // This method gets called by the runtime. 
    // Use this method to add services to the container.
    // For more information on how to configure your application, 
    // visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddRazorPages();

      string databasePath = Path.Combine("..", "Northwind.db");

      services.AddDbContext<Northwind>(options => 
        options.UseSqlite($"Data Source={databasePath}"));
    }

    // This method gets called by the runtime. 
    // Use this method to configure the HTTP request pipeline.
    public void Configure(
      IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseRouting();

      app.Use(async (HttpContext context, Func<Task> next) =>
      {
        var rep = context.GetEndpoint() as RouteEndpoint;
        if (rep != null)
        {
          WriteLine($"Endpoint name: {rep.DisplayName}");
          WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
        }

        if (context.Request.Path == "/bonjour")
        {
          // in the case of a match on URL path, this becomes a terminating
          // delegate that returns so does not call the next delegate
          await context.Response.WriteAsync("Bonjour Monde!");
          return; 
        }
        // we could modify the request before calling the next delegate
        await next();
        // we could modify the response after calling the next delegate
      });

      app.UseHttpsRedirection();

      app.UseDefaultFiles(); // index.html, default.html, and so on
      app.UseStaticFiles();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapRazorPages();
        
        endpoints.MapGet("/hello", async context =>
        {
         await context.Response.WriteAsync("Hello World!");
        });
      });
    }
  }
}