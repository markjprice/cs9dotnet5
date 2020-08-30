using Foundation;
using NorthwindMobile.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]

namespace NorthwindMobile.iOS
{
  public class PhoneDialer : IDialer
  {
    public bool Dial(string number)
    {
      return UIApplication.SharedApplication.OpenUrl(
        new NSUrl("tel:" + number));
    }
  }
}