using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace NorthwindFluent
{
  class CategoryIDToImageConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, 
      object parameter, string language)
    {
      int number = (int)value;

      string path = string.Format(
        format: "{0}/Assets/category{1}-small.jpeg",
        arg0: Environment.CurrentDirectory, 
        arg1: number);

      var image = new BitmapImage(new Uri(path));

      return image;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      throw new NotImplementedException();
    }
  }
}
