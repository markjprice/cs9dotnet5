using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Packt.Shared
{
  public class Category
  {
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Product> Products { get; set; }

    public Category()
    {
      this.Products = new HashSet<Product>();
    }
  }

  public class Product
  {
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; } 
    public bool Discontinued { get; set; }
    public int CategoryID { get; set; }

    public virtual Category Category { get; set; }
  }

  public class Northwind : DbContext
  {
    public DbSet<Category> Categories { get; set; } 
    public DbSet<Product> Products { get; set; }

    public Northwind(DbContextOptions options)
      : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Category>()
        .HasMany(c => c.Products)
        .WithOne(p => p.Category);

      modelBuilder.Entity<Product>()
        .HasOne(p => p.Category)
        .WithMany(c => c.Products);
    }
  }
}