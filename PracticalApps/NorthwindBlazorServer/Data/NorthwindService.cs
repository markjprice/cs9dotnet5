using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;

namespace NorthwindBlazorServer.Data
{
  public class NorthwindService : INorthwindService
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
      return db.Customers.FirstOrDefaultAsync
        (c => c.CustomerID == id);
    }

    public Task<Customer> CreateCustomerAsync(Customer c)
    {
      db.Customers.Add(c);
      db.SaveChangesAsync();
      return Task.FromResult<Customer>(c);
    }

    public Task<Customer> UpdateCustomerAsync(Customer c)
    {
      db.Entry(c).State = EntityState.Modified;
      db.SaveChangesAsync();
      return Task.FromResult<Customer>(c);
    }

    public Task DeleteCustomerAsync(string id)
    {
      Customer customer = db.Customers.FirstOrDefaultAsync
        (c => c.CustomerID == id).Result;
      db.Customers.Remove(customer);
      return db.SaveChangesAsync();
    }
  }
}