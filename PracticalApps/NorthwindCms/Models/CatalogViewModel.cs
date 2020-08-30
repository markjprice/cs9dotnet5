using System.Collections.Generic;

namespace NorthwindCms.Models
{
  public class CatalogViewModel
  {
    public CatalogPage CatalogPage { get; set; }
    public IEnumerable<CategoryItem> Categories { get; set; }
  }
}