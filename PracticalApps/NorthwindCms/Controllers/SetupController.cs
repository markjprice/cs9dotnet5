using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.Extend;
using Piranha.Extend.Blocks;
using NorthwindCms.Models;

namespace NorthwindCms.Controllers
{
    /// <summary>
    /// This controller is only used when the project is first started
    /// and no pages has been added to the database. Feel free to remove it.
    /// </summary>
    public class SetupController : Controller
    {
        private readonly IApi _api;

        public SetupController(IApi api)
        {
            _api = api;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/seed")]
        public async Task<IActionResult> Seed()
        {
            // Get the default site
            var site = await _api.Sites.GetDefaultAsync();
            site.SiteTypeId = nameof(BlogSite);
            await _api.Sites.SaveAsync(site);

            // Add media assets
            var bannerId = Guid.NewGuid();
            using (var stream = System.IO.File.OpenRead("seed/pexels-photo-355423.jpeg"))
            {
                await _api.Media.SaveAsync(new Piranha.Models.StreamMediaContent()
                {
                    Id = bannerId,
                    Filename = "pexels-photo-355423.jpeg",
                    Data = stream
                });
            }
            var banner = await _api.Media.GetByIdAsync(bannerId);

            var logoId = Guid.NewGuid();
            using (var stream = System.IO.File.OpenRead("seed/logo.png"))
            {
                await _api.Media.SaveAsync(new Piranha.Models.StreamMediaContent()
                {
                    Id = logoId,
                    Filename = "logo.png",
                    Data = stream
                });
            }

            // Add the site info
            var blogSite = await BlogSite.CreateAsync(_api);
            blogSite.Information.SiteLogo = logoId;
            blogSite.Information.SiteTitle = "Piranha CMS";
            blogSite.Information.Tagline = "A lightweight & unobtrusive CMS for Asp.NET Core.";
            await _api.Sites.SaveContentAsync(site.Id, blogSite);

            // Add the blog archive
            var blogId = Guid.NewGuid();
            var blogPage = await BlogArchive.CreateAsync(_api);
            blogPage.Id = blogId;
            blogPage.SiteId = site.Id;
            blogPage.Title = "Blog Archive";
            blogPage.MetaKeywords = "Inceptos, Tristique, Pellentesque, Lorem, Vestibulum";
            blogPage.MetaDescription = "Morbi leo risus, porta ac consectetur ac, vestibulum at eros.";
            blogPage.NavigationTitle = "Blog";
            blogPage.Published = DateTime.Now;

            await _api.Pages.SaveAsync(blogPage);

            // Add a blog post
            var post = await BlogPost.CreateAsync(_api);
            post.BlogId = blogPage.Id;
            post.Category = "Piranha CMS";
            post.Tags.Add("Welcome", "Fresh Start", "Information");
            post.Title = "Welcome to Piranha CMS!";
            post.MetaKeywords = "Welcome, Piranha CMS, AspNetCore, MVC, .NET Core";
            post.MetaDescription = "Piranha is the fun, fast and lightweight framework for developing cms-based web applications with ASP.Net Core.";
            post.Hero.PrimaryImage = bannerId;
            post.Hero.Ingress = "<p>Piranha CMS is a <strong>lightweight</strong>, <strong>cross-platform</strong> CMS <string>library</string> for <code>NetStandard 2.0</code>, <code>.NET Core</code> & <code>Entity Framework Core</code>. It can be used to add CMS functionality to your existing application or to build a new website from scratch. It has an extensible & pluggable architecture that can support a wide variety of runtime scenarios.</p>";
            post.Blocks.Add(new HtmlBlock
            {
                Body = "<p>Piranha CMS is a <strong>lightweight</strong>, <strong>cross-platform</strong> CMS <string>library</string> for <code>NetStandard 2.0</code>, <code>.NET Core</code> & <code>Entity Framework Core</code>. It can be used to add CMS functionality to your existing application or to build a new website from scratch. It has an extensible & pluggable architecture that can support a wide variety of runtime scenarios.</p><p>Piranha CMS is totally <strong>package based</strong> and available on <code>NuGet</code>. You can read more about the different packages available in the documentation.</p>"
            });
            post.Blocks.Add(new HtmlBlock
            {
                Body = "<h2>Getting Started</h2><p>To log into the manager interface and start writing content simply go the URL <code>/manager</code> and login with <code>admin</code> / <code>password</code> as your username and password.</p>"
            });
            post.Blocks.Add(new HtmlBlock
            {
                Body = "<h2>Licensing</h2><p>Piranha CMS is released under the <strong>MIT</strong> license. It is a permissive free software license, meaning that it permits reuse within proprietary software provided all copies of the licensed software include a copy of the MIT License terms and the copyright notice.</p>"
            });
            post.Published = DateTime.Now;
            await _api.Posts.SaveAsync(post);

            // Add about page
            var page = await StandardPage.CreateAsync(_api);
            page.SiteId = site.Id;
            page.SortOrder = 1;
            page.Title = "About Me";
            page.MetaKeywords = "Inceptos, Tristique, Pellentesque, Lorem, Vestibulum";
            page.MetaDescription = "Morbi leo risus, porta ac consectetur ac, vestibulum at eros.";
            page.Blocks.Add(new HtmlBlock
            {
                Body = "<p>Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Donec sed odio dui. Vestibulum id ligula porta felis euismod semper. Nulla vitae elit libero, a pharetra augue. Donec id elit non mi porta gravida at eget metus. Donec ullamcorper nulla non metus auctor fringilla.</p>"
            });
            page.Blocks.Add(new QuoteBlock
            {
                Body = "Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod."
            });
            page.Blocks.Add(new ColumnBlock
            {
                Items = new List<Block>
                {
                    new HtmlBlock
                    {
                        Body = $"<p><img src=\"{banner.PublicUrl.Replace("~", "")}\"></p>"
                    },
                    new HtmlBlock
                    {
                        Body = "<p>Maecenas faucibus mollis interdum. Aenean lacinia bibendum nulla sed consectetur. Integer posuere erat a ante venenatis dapibus posuere velit aliquet.</p>"
                    }
                }
            });
            page.Published = DateTime.Now;
            await _api.Pages.SaveAsync(page);

            return Redirect("~/");
        }
    }
}
