using Microsoft.ML.Data;

namespace NorthwindML.Models
{
  public class ProductCobought
  {
    [KeyType(77)] // maximum possible value of a ProductID
    public uint ProductID { get; set; }

    [KeyType(77)]
    public uint CoboughtProductID { get; set; }
  }
}