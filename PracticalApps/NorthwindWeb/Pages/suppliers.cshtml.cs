using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages
{
  public class SuppliersModel : PageModel
  {
    private Northwind db;

    public SuppliersModel(Northwind injectedContext)
    {
      db = injectedContext;
    }

    public IEnumerable<string> Suppliers { get; set; }

    public void OnGet()
    {
      ViewData["Title"] = "Northwind Web Site - Suppliers";

      Suppliers = db.Suppliers.Select(s => s.CompanyName);

      // Suppliers = new[] {
      //   "Alpha Co", "Beta Limited", "Gamma Corp"
      // };
    }

    [BindProperty]
    public Supplier Supplier { get; set; }

    public IActionResult OnPost()
    {
      if (ModelState.IsValid)
      {
        db.Suppliers.Add(Supplier);
        db.SaveChanges();
        return RedirectToPage("/suppliers");
      }
      return Page();
    }
  }
}