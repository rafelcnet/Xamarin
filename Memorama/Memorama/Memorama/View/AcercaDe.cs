using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Memorama
{
    class AcercaDe : ContentPage
    {
        public AcercaDe()
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

            imagen.Source = ImageSource.FromFile("person.png");
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
