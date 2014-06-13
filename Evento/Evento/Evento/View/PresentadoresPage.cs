using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Evento
{
    class PresentadoresPage : ContentPage 
    {

        public PresentadoresPage()
        {
            BindingContext = new EventoData();

            Title = "Presentadores";
            Icon = "tabspeaker.png";
            BackgroundImage = "background.png";

            StackLayout panel = new StackLayout
            {
                Spacing = 6,
            };

            ListView listaPresentadores = new ListView();
            listaPresentadores.SetBinding(ListView.ItemsSourceProperty, new Binding("Speakers", BindingMode.OneWay));
            listaPresentadores.ItemTemplate = new DataTemplate(typeof(PresentadorCell));
            listaPresentadores.RowHeight = 56;

            listaPresentadores.ItemSelected += (sender, e) => {
                var item = (Speaker)e.SelectedItem;
                SpeakerDetailPage speakerPage = new SpeakerDetailPage();
                speakerPage.BindingContext = item;
                Navigation.PushAsync(speakerPage);
            };

            panel.Children.Add(listaPresentadores);
            Content = panel;

        }

        public class PresentadorCell : ViewCell {
            public PresentadorCell() {
                var image = new Image { 
                    HorizontalOptions = LayoutOptions.Start,
                };
                image.SetBinding(Image.SourceProperty, new Binding("Foto"));
                image.WidthRequest = image.HeightRequest = 46;

                var nameLabel = new Label
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                };
                nameLabel.SetBinding(Label.TextProperty, "Nombre");

                var viewLayout = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { image, nameLabel}
                };
                View = viewLayout;
            }
        }
    }
}
