using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Memorama
{
    public class App
    {
        public static double Height = 0;
        public static double Width = 0;
        public static INavigation Navigation { get; set; }
        public static Page GetMainPage()
        {
            var mainNav = new NavigationPage(new MainPage());
            Navigation = mainNav.Navigation;
            mainNav.BarBackgroundColor = Color.FromHex("0x2C3E50");
            return mainNav;
        }

        public class MainPage : TabbedPage
        {
            public MainPage()
            {
                this.Title = "Memorama App";
                this.Children.Add(new Settings());
                this.Children.Add(new AcercaDe());
                this.Padding = new Thickness(20, Device.OnPlatform(40, 20, 20), 20, 20);
                BackgroundColor = Color.Gray;
            }
        }
    }
}
