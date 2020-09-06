using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;

namespace NorthwindBlazorWasm.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CustomersController : ControllerBase
  {
    private readonly Northwind db;

    public CustomersController(Northwind db)
    {
      this.db = db;
    }

    [HttpGet]
    public async Task<List<Customer>> GetCustomersAsync()
    {
      return await db.Customers.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Customer> GetCustomerAsync(string id)
    {
      return await db.Customers.FirstOrDefaultAsync
        (c => c.CustomerID == id);
    }

    [HttpPost]
    public async Task<Customer> CreateCustomerAsync(Customer customerToAdd)
    {
      Customer existing = await db.Customers.FirstOrDefaultAsync
        (c => c.CustomerID == customerToAdd.CustomerID);

      if (existing == null)
      {
        db.Customers.Add(customerToAdd);
        int affected = await db.SaveChangesAsync();
        if (affected == 1)
        {
          return customerToAdd;
        }
      }
      return existing;
    }

    [HttpPut]
    public async Task<Customer> UpdateCustomerAsync(Customer c)
    {
      db.Entry(c).State = EntityState.Modified;
      int affected = await db.SaveChangesAsync();
      if (affected == 1)
      {
        return c;
      }
      return null;
    }

    [HttpDelete("{id}")]
    public async Task<int> DeleteCustomerAsync(string id)
    {
      Customer c = await db.Customers.FirstOrDefaultAsync
        (c => c.CustomerID == id);

      if (c != null)
      {
        db.Customers.Remove(c);
        int affected = await db.SaveChangesAsync();
        return affected;
      }
      
      return 0;
    }
  }
}