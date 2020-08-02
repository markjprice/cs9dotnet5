namespace Packt.Shared
{
  public class OrderDetail
  {
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public decimal UnitPrice { get; set; } = 0;
    public short Quantity { get; set; } = 1;
    public double Discount { get; set; } = 0;

    // related entities
    public Order Order { get; set; }
    public Product Product { get; set; }
  }
}