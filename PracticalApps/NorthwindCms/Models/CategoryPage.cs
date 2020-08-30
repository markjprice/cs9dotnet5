using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using System.Collections.Generic;

namespace NorthwindCms.Models
{
  [PageType(Title = "Category Page", UseBlocks = false)]
  [PageTypeRoute(Title = "Default", Route = "/catalog-category")]
  public class CategoryPage : Page<CategoryPage>
  {
    [Region(Title = "Category detail")]
    [RegionDescription("The details for this category.")]
    public CategoryRegion CategoryDetail { get; set; }

    [Region(Title = "Category products")]
    [RegionDescription("The products for this category.")]
    public IList<ProductRegion> Products
      { get; set; } = new List<ProductRegion>();
  }
}