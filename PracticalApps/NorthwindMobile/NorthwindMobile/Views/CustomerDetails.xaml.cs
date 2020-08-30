using System;
using NorthwindMobile.Models;
using Xamarin.Forms;

namespace NorthwindMobile.Views
{
  public partial class CustomerDetails : ContentPage
  {
    public CustomerDetails()
    {
      InitializeComponent();

      BindingContext = new Customer();
      Title = "Add Customer";
    }

    public CustomerDetails(Customer customer)
    {
      InitializeComponent();

      BindingContext = customer;
      InsertButton.IsVisible = false;
    }

    async void InsertButton_Clicked(object sender, EventArgs e)
    {
      Customer.Customers.Add((Customer)BindingContext);
      await Navigation.PopAsync(animated: true);
    }
  }
}