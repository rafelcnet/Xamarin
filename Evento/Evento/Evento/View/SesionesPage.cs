using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Evento
{
    class SesionesPage : ContentPage
    {

        public SesionesPage()
        {
            BindingContext = new EventoData();

            Title = "Sesiones";
            Icon = "tabsession.png";
            BackgroundImage = "background.png";

            StackLayout panel = new StackLayout
            {
                Spacing = 6,
            };

            ListView listaSesiones = new ListView();
            listaSesiones.SetBinding(ListView.ItemsSourceProperty, new Binding("Sessions", BindingMode.OneWay));
            listaSesiones.ItemTemplate = new DataTemplate(typeof(SessionCell));
            listaSesiones.RowHeight = 64;

            listaSesiones.ItemSelected += (sender, e) =>
            {
                var item = (Session)e.SelectedItem;
                SessionDetailPage sessionPage = new SessionDetailPage();
                sessionPage.BindingContext = item;
                Navigation.PushAsync(sessionPage);
            };

            panel.Children.Add(listaSesiones);
            Content = panel;
        }

        public class SessionCell : ViewCell
        {
            public SessionCell()
            {
                var nameLabel = new Label
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                };
                nameLabel.SetBinding(Label.TextProperty, "Titulo");

                var speakerLabel = new Label
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                };
                speakerLabel.SetBinding(Label.TextProperty, "Speaker");

                var viewLayout = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    Children = { nameLabel, speakerLabel },
                    Padding = 4,
                };
                View = viewLayout;
            }
        }
    }
}
