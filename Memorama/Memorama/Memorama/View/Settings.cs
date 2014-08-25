using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Memorama
{
    public class Settings : ContentPage
    {
        int nivel = 0;
        public Settings()
        {
            Title = "Juego de Memoria";
            Icon = "house.png";

            StackLayout panel = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 10,
                Padding = new Thickness(20, Device.OnPlatform(40, 20, 20), 20, 20),
            };

            Button start = new Button
            {
                Text = "Iniciar juego",
                TextColor = Color.White,
                BackgroundColor = Color.Green,
            };

            start.Clicked += delegate
            {
                App.Navigation.PushAsync(new GamePage(nivel, this.Width));
            };

            panel.Children.Add(new Label
            {
                Text = "Dificultad",
                TextColor = Color.Black,
            });

            var dificultad = new Picker
            {
                Title = "Dificultad",
            };
            dificultad.Items.Add("Fácil");
            dificultad.Items.Add("Normal");
            dificultad.SelectedIndex = 0;
            dificultad.SelectedIndexChanged += (sender, args) =>
            {
                nivel = dificultad.SelectedIndex;
            };

            panel.Children.Add(dificultad);
            panel.Children.Add(start);

            panel.Children.Add(new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Text = "\n\n\nMemorama versión 1.0.0\nRafaelcNet 2014",
                Font = Font.SystemFontOfSize(18),
                TextColor = Color.Black,
            });

            Content = panel;

        }
    }
}
