using System.Collections.Generic;

namespace NorthwindML.Models
{
  public class Cart
  {
    public IEnumerable<CartItem> Items { get; set; }
  }
}