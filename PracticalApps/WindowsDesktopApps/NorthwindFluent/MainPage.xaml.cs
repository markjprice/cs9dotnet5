using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NorthwindFluent
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
    }

    private void NavView_Loaded(object sender, RoutedEventArgs e)
    {
      NavView.MenuItems.Add(new NavigationViewItem
      {
        Content = "Categories",
        Icon = new SymbolIcon(Symbol.BrowsePhotos),
        Tag = "categories"
      });

      NavView.MenuItems.Add(new NavigationViewItem
      {
        Content = "Products",
        Icon = new SymbolIcon(Symbol.AllApps),
        Tag = "products"
      });

      NavView.MenuItems.Add(new NavigationViewItem
      {
        Content = "Suppliers",
        Icon = new SymbolIcon(Symbol.Contact2),
        Tag = "suppliers"
      });

      NavView.MenuItems.Add(new NavigationViewItemSeparator());

      NavView.MenuItems.Add(new NavigationViewItem
      {
        Content = "Customers",
        Icon = new SymbolIcon(Symbol.People),
        Tag = "customers"
      });

      NavView.MenuItems.Add(new NavigationViewItem
      {
        Content = "Orders",
        Icon = new SymbolIcon(Symbol.PhoneBook),
        Tag = "orders"
      });

      NavView.MenuItems.Add(new NavigationViewItem
      {
        Content = "Shippers",
        Icon = new SymbolIcon(Symbol.PostUpdate),
        Tag = "shippers"
      });
    }

    private void NavView_ItemInvoked(NavigationView sender,
      NavigationViewItemInvokedEventArgs args)
    {
      switch (args.InvokedItem.ToString())
      {
        case "Categories":
          ContentFrame.Navigate(typeof(CategoriesPage));
          break;
        default:
          ContentFrame.Navigate(typeof(NotImplementedPage));
          break;
      }
    }

    private async void RefreshButton_Click(
      object sender, RoutedEventArgs e)
    {
      var notImplementedDialog = new ContentDialog
      {
        Title = "Not implemented",
        Content =
"The Refresh functionality has not yet been implemented.",
        CloseButtonText = "OK"
      };

      ContentDialogResult result =
        await notImplementedDialog.ShowAsync();
    }
  }
}
