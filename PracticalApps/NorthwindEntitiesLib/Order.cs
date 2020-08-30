using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Packt.Shared
{
  [Index(nameof(CustomerID), Name = "CustomerID")]
  [Index(nameof(CustomerID), Name = "CustomersOrders")]
  [Index(nameof(EmployeeID), Name = "EmployeeID")]
  [Index(nameof(EmployeeID), Name = "EmployeesOrders")]
  [Index(nameof(OrderDate), Name = "OrderDate")]
  [Index(nameof(ShipPostalCode), Name = "ShipPostalCode")]
  [Index(nameof(ShippedDate), Name = "ShippedDate")]
  [Index(nameof(ShipVia), Name = "ShippersOrders")]
  public partial class Order
  {
    public Order()
    {
      OrderDetails = new HashSet<OrderDetail>();
    }

    [Key]
    public long OrderID { get; set; }

    [Column(TypeName = "nchar (5)")]
    [StringLength(5)]
    public string CustomerID { get; set; }

    [Column(TypeName = "int")]
    public long? EmployeeID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequiredDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ShippedDate { get; set; }

    [Column(TypeName = "int")]
    public long? ShipVia { get; set; }

    [Column(TypeName = "money")]
    public decimal? Freight { get; set; }

    [Column(TypeName = "nvarchar (40)")]
    [StringLength(40)]
    public string ShipName { get; set; }

    [Column(TypeName = "nvarchar (60)")]
    [StringLength(60)]
    public string ShipAddress { get; set; }

    [Column(TypeName = "nvarchar (15)")]
    [StringLength(15)]
    public string ShipCity { get; set; }

    [Column(TypeName = "nvarchar (15)")]
    [StringLength(15)]
    public string ShipRegion { get; set; }

    [Column(TypeName = "nvarchar (10)")]
    [StringLength(10)]
    public string ShipPostalCode { get; set; }

    [Column(TypeName = "nvarchar (15)")]
    [StringLength(15)]
    public string ShipCountry { get; set; }

    [ForeignKey(nameof(CustomerID))]
    [InverseProperty("Orders")]
    public virtual Customer Customer { get; set; }

    [ForeignKey(nameof(EmployeeID))]
    [InverseProperty("Orders")]
    public virtual Employee Employee { get; set; }

    [ForeignKey(nameof(ShipVia))]
    [InverseProperty(nameof(Shipper.Orders))]
    public virtual Shipper ShipViaNavigation { get; set; }

    [InverseProperty(nameof(OrderDetail.Order))]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
  }
}