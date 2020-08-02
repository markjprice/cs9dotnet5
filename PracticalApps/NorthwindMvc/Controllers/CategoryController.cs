using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NorthwindMvc.Controllers
{
  public class CategoryController : Controller
  {
    private readonly ILogger<CategoryController> _logger;

    private readonly Northwind db;

    public CategoryController(
      ILogger<CategoryController> logger,
      Northwind injectedContext)
    {
      _logger = logger;
      db = injectedContext;
    }

    // default route would be category/index/1
    // so we can simplify that
    [Route("category/{id:int?}")]
    public async Task<IActionResult> Index(int? id)
    {
      if (!id.HasValue)
      {
        return NotFound("You must pass a category ID in the route, for example, /category/2");
      }

      Category model = await db.Categories
        .SingleOrDefaultAsync(c => c.CategoryID == id);

      if (model == null)
      {
        return NotFound($"Category with ID of {id} not found.");
      }

      return View(model);
    }
  }
}