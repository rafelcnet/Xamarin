using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Evento
{
    public class App
    {
        public static Page GetMainPage()
        {
            var mainNav = new NavigationPage(new MainPage());
            mainNav.Tint = Color.FromRgb(34,124,28);
            return mainNav;
        }

        public class MainPage : TabbedPage
        {

            public MainPage() {
                this.Title = "Eventos de desarrollo";
                Children.Add(new PresentadoresPage());
                Children.Add(new SesionesPage());
                Children.Add(new AcercaDePage());
            }

        }
    }
}
