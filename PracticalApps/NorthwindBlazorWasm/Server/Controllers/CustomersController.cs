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
    public async Task<int> CreateCustomerAsync(Customer c)
    {
      db.Customers.Add(c);
      return await db.SaveChangesAsync();
    }

    [HttpPut]
    public async Task<int> UpdateCustomerAsync(Customer c)
    {
      db.Entry(c).State = EntityState.Modified;
      return await db.SaveChangesAsync();
    }

    [HttpDelete]
    public async Task<int> DeleteCustomerAsync(Customer c)
    {
      db.Customers.Remove(c);
      return await db.SaveChangesAsync();
    }
  }
}