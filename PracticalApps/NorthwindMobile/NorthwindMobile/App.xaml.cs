using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NorthwindMobile.Views;

namespace NorthwindMobile
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new CustomersList());
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
