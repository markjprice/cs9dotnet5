using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;

namespace NorthwindBlazorServer.Data
{
  public class NorthwindService
  {
    private readonly Northwind db;

    public NorthwindService(Northwind db)
    {
      this.db = db;
    }

    public Task<List<Customer>> GetCustomersAsync()
    {
      return db.Customers.ToListAsync();
    }

    public Task<Customer> GetCustomerAsync(string id)
    {
      return db.Customers.FirstOrDefaultAsync(c => c.CustomerID == id);
    }

    public Task<int> CreateCustomerAsync(Customer c)
    {
      db.Customers.Add(c);
      return db.SaveChangesAsync();
    }

    public Task<int> UpdateCustomerAsync(Customer c)
    {
      db.Entry(c).State = EntityState.Modified;
      return db.SaveChangesAsync();
    }

    public Task<int> DeleteCustomerAsync(Customer c)
    {
      db.Customers.Remove(c);
      return db.SaveChangesAsync();
    }
  }
}