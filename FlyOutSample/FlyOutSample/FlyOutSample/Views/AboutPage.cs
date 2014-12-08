using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlyOutSample
{
  public class AboutPage : ContentPage
  {
    public AboutPage()
    {
      Title = "Acerca de";
      StackLayout panel = new StackLayout
      {
        VerticalOptions = LayoutOptions.FillAndExpand,
        HorizontalOptions = LayoutOptions.FillAndExpand,
        Orientation = StackOrientation.Vertical,
        Spacing = 15,
        Padding = new Thickness(20, Device.OnPlatform(40, 20, 20), 20, 20),
      };
      panel.Children.Add(new Label
      {
        Text = "Pemex H&F",
        TextColor = Color.Black,
        Font = Font.SystemFontOfSize(14),
        HorizontalOptions = LayoutOptions.Center
      });
      panel.Children.Add(new Label
      {
        Text = "(versión 1.0, build 1.0.0)",
        TextColor = Color.Black,
        Font = Font.SystemFontOfSize(12),
        HorizontalOptions = LayoutOptions.Center
      });
      //BackgroundImage = "fondoimg.png";
      BackgroundColor = Color.Silver;
      panel.Children.Add(new Label
      {
        Text = "Aplicación desarrollada por:",
        TextColor = Color.Black,
      });

      var imagen = new Image
      {
        HorizontalOptions = LayoutOptions.Center,
      };

      imagen.Source = ImageSource.FromFile("csharp.jpeg");
      panel.Children.Add(imagen);

      panel.Children.Add(new Label
      {
        Text = "Rafael Cárdenas",
        TextColor = Color.Black,
      });

      Content = panel;
    }
  }
}
