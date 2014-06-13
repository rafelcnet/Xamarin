using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Evento
{
    public class SessionDetailPage : ContentPage 
    {

        public class DateTimeConverter : IValueConverter {

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var s = (DateTime)value;
                return s.ToString("g");
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var s = value as string;
                return DateTime.Parse(s);
            }
        }
       
        public SessionDetailPage(){
            NavigationPage.SetHasNavigationBar (this, true);
            BackgroundColor = Color.White;

            var speakerLabel = new Label { TextColor = Color.Gray };
            speakerLabel.SetBinding(Label.TextProperty, new Binding("Speaker"));

            var tituloLabel = new Label { TextColor = Color.Navy };
            tituloLabel.SetBinding(Label.TextProperty, new Binding("Titulo"));

            var resumenLabel = new Label {
                TextColor = Color.FromRgb(27,77,125),
                HeightRequest = 160,
            };
            resumenLabel.SetBinding(Label.TextProperty, new Binding("Resumen"));

            var lugarLabel = new Label { TextColor = Color.Gray };
            lugarLabel.SetBinding(Label.TextProperty, new Binding("Lugar"));

            var fechaLabel = new Label { TextColor = Color.Gray };
            fechaLabel.SetBinding(Label.TextProperty, new Binding("Inicia", BindingMode.OneWay, new DateTimeConverter()));

            var linea = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Spacing = 6,
            };

            linea.Children.Add(new Label { Text = "Inicia: ", TextColor = Color.Gray });
            linea.Children.Add(fechaLabel);

            var addEvento = new Button
            {
                Text = "Agregar evento",
                BackgroundColor = Color.Green,
            };

            addEvento.Clicked += delegate {
                Session sesion = (Session)this.BindingContext;
                var calendario = DependencyService.Get<ICalendar>();
                if (calendario != null)
                    calendario.AddEvent(sesion.Titulo + " por " + sesion.Speaker, sesion.Lugar, sesion.Inicia, sesion.Termina, sesion.Resumen);
            };

            Content = new StackLayout { 
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = 10,
                Children = {
                    tituloLabel, speakerLabel, lugarLabel, linea, addEvento, resumenLabel
                }
            };

        }
    }
}
