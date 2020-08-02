using System.Collections.Generic;
using Packt.Shared;

namespace NorthwindMvc.Models
{
  public class HomeIndexViewModel
  {
    public int VisitorCount;
    public IList<Category> Categories { get; set; } 
    public IList<Product> Products { get; set; }
  }
}