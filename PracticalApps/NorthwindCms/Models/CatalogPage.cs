using Piranha.AttributeBuilder;
using Piranha.Models;

namespace NorthwindCms.Models
{
  [PageType(Title = "Catalog page", UseBlocks = false)]
  [PageTypeRoute(Title = "Default", Route = "/catalog")]
  public class CatalogPage : Page<CatalogPage>
  {
  }
}