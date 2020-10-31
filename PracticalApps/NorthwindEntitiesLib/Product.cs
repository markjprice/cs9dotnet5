using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Packt.Shared
{
  [Index(nameof(CategoryID), Name = "CategoriesProducts")]
  [Index(nameof(CategoryID), Name = "CategoryID")]
  [Index(nameof(ProductName), Name = "ProductName")]
  [Index(nameof(SupplierID), Name = "SupplierID")]
  [Index(nameof(SupplierID), Name = "SuppliersProducts")]
  public partial class Product
  {
    public Product()
    {
      OrderDetails = new HashSet<OrderDetail>();
    }

    [Key]
    public long ProductID { get; set; }

    [Required]
    [Column(TypeName = "nvarchar (40)")]
    [StringLength(40)]
    public string ProductName { get; set; }

    [Column(TypeName = "int")]
    public long? SupplierID { get; set; }

    [Column(TypeName = "int")]
    public long? CategoryID { get; set; }

    [Column(TypeName = "nvarchar (20)")]
    [StringLength(20)]
    public string QuantityPerUnit { get; set; }

    [Column(TypeName = "money")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "smallint")]
    public short? UnitsInStock { get; set; }

    [Column(TypeName = "smallint")]
    public short? UnitsOnOrder { get; set; }

    [Column(TypeName = "smallint")]
    public short? ReorderLevel { get; set; }

    [Required]
    [Column(TypeName = "bit")]
    public bool Discontinued { get; set; }

    [ForeignKey(nameof(CategoryID))]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; }

    [ForeignKey(nameof(SupplierID))]
    [InverseProperty("Products")]
    public virtual Supplier Supplier { get; set; }

    [InverseProperty(nameof(OrderDetail.Product))]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
  }
}