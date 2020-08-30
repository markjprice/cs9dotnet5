using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NorthwindMobile.Models;
using Xamarin.Forms;

namespace NorthwindMobile.Views
{
  public partial class CustomersList : ContentPage
  {
    public CustomersList()
    {
      InitializeComponent();

      Customer.Customers.Clear();

      try
      {
        var client = new HttpClient
        {
          BaseAddress = new Uri("http://localhost:5003/")
        };

        client.DefaultRequestHeaders.Accept.Add(
          new MediaTypeWithQualityHeaderValue(
          "application/json"));

        HttpResponseMessage response = client
          .GetAsync("api/customers").Result;

        response.EnsureSuccessStatusCode();

        string content = response.Content
          .ReadAsStringAsync().Result;

        var customersFromService = JsonConvert
          .DeserializeObject<IEnumerable<Customer>>(content);

        foreach (Customer c in customersFromService
          .OrderBy(customer => customer.CompanyName))
        {
          Customer.Customers.Add(c);
        }
      }
      catch (Exception ex)
			{
        DisplayAlert(title: "Exception",
          message: $"App will use sample data due to: {ex.Message}", 
          cancel: "OK");

        Customer.AddSampleData();
      }

      BindingContext = Customer.Customers;
    }

    async void Customer_Tapped(
      object sender, ItemTappedEventArgs e)
    {
      var c = e.Item as Customer;

      if (c == null) return;

      // navigate to the detail view and show the tapped customer 
      await Navigation.PushAsync(new CustomerDetails(c));
    }

    async void Customers_Refreshing(object sender, EventArgs e)
    {
      var listView = sender as ListView;
      listView.IsRefreshing = true;
      // simulate a refresh
      await Task.Delay(1500);
      listView.IsRefreshing = false;
    }

    void Customer_Deleted(object sender, EventArgs e)
    {
      var menuItem = sender as MenuItem;
      Customer c = menuItem.BindingContext as Customer;
      Customer.Customers.Remove(c);
    }

    async void Customer_Phoned(object sender, EventArgs e)
    {
      var menuItem = sender as MenuItem;
      var c = menuItem.BindingContext as Customer;

      if (await this.DisplayAlert("Dial a Number",
        "Would you like to call " + c.Phone + "?",
        "Yes", "No"))
      {
        var dialer = DependencyService.Get<IDialer>();

        if (dialer != null) dialer.Dial(c.Phone);
      }
    }

    async void Add_Activated(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new CustomerDetails());
    }
  }
}