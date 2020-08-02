namespace Packt.Shared
{
  public class Product
  {
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int? SupplierID { get; set; }
    public int? CategoryID { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal? UnitPrice { get; set; } = 0;
    public short? UnitsInStock { get; set; } = 0;
    public short? UnitsOnOrder { get; set; } = 0;
    public short? ReorderLevel { get; set; } = 0;
    public bool Discontinued { get; set; } = false;

    // related entities
    public Category Category { get; set; }
    public Supplier Supplier { get; set; }
  }
}