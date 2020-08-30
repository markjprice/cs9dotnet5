using Piranha.Extend;
using Piranha.Extend.Fields;

namespace NorthwindCms.Models
{
  public class CategoryRegion
  {
    [Field(Title = "Category ID")]
    public NumberField CategoryID { get; set; }

    [Field(Title = "Category name")]
    public TextField CategoryName { get; set; }

    [Field]
    public HtmlField Description { get; set; }

    [Field(Title = "Category image")]
    public ImageField CategoryImage { get; set; }
  }
}