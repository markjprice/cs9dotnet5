using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using Packt.Shared;

namespace NorthwindWeb.Pages
{
  public class CustomersByCountryModel : PageModel
  {
    private Northwind db;

    public CustomersByCountryModel(Northwind injectedContext)
    {
      db = injectedContext;
    }

    public ILookup<string, Customer> CustomersByCountry { get; set; }

    public void OnGet()
    {
      ViewData["Title"] = "Northwind Website - Customers By Country";

      CustomersByCountry = db.Customers
        // sort by Country then CompanyName
        .OrderBy(customer => customer.Country)
        .ThenBy(customer => customer.CompanyName)
        // group by Country into a lookup e.g. grouped dictionary
        .ToLookup(customer => customer.Country);
    }
  }
}