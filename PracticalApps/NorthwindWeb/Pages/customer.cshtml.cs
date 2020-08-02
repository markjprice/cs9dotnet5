using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NorthwindWeb.Pages
{
  public class CustomerModel : PageModel
  {
    private Northwind db;

    public CustomerModel(Northwind injectedContext)
    {
      db = injectedContext;
    }

    [BindProperty]
    public Customer Customer { get; set; }

    // automatically get the id from query string
    // e.g. /customer?id=ALFKI
    [BindProperty(SupportsGet = true)]
    public string ID { get; set; }

    public void OnGet()
    {
      ViewData["Title"] = "Northwind Web Site - Customer";

      Customer = db.Customers
        .Where(c => c.CustomerID == ID)   // get the customer with this ID
        .Include(c => c.Orders)           // ...and their orders
        .ThenInclude(o => o.OrderDetails) // ...with order details
        .ThenInclude(d => d.Product)      // ...and product details
        .FirstOrDefault();                // limit to the first customer.
    }
  }
}