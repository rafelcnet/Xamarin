using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FormsMVVMDemo1
{
    public class App
    {
        public static Page GetMainPage()
        {
            return new MainPage();
        }

        public class MainPage : ContentPage
        {
            public Label resultado;
            public Entry numero1;
            public Entry numero2;
            public Entry numero3;
            public Label texto;
            public Button botonSencillo;

            public MainPage()
            {

                BindingContext = new Numeros();

                StackLayout panel = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Spacing = 10,
                };

                StackLayout renglon1 = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 8,
                    Padding = 4,
                };
                renglon1.Children.Add(new Label
                {
                    Text = "Numero 1:",
                });
                renglon1.Children.Add(numero1 = new Entry());
                numero1.WidthRequest = 160;
                panel.Children.Add(renglon1);

                StackLayout renglon2 = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 8,
                    Padding = 4,
                };
                renglon2.Children.Add(new Label
                {
                    Text = "Numero 2:",
                });
                renglon2.Children.Add(numero2 = new Entry());
                numero2.WidthRequest = 160;
                panel.Children.Add(renglon2);

                StackLayout renglon3 = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 8,
                    Padding = 4,
                };
                renglon3.Children.Add(new Label
                {
                    Text = "Numero 3:",
                });
                renglon3.Children.Add(numero3 = new Entry());
                numero3.WidthRequest = 160;
                panel.Children.Add(renglon3);

                panel.Children.Add(resultado = new Label
                {
                    Text="0",
                });

                numero1.SetBinding(Entry.TextProperty, new Binding("Numero1", BindingMode.TwoWay) );
                numero2.SetBinding(Entry.TextProperty, new Binding("Numero2", BindingMode.TwoWay));
                numero3.SetBinding(Entry.TextProperty, new Binding("Numero3", BindingMode.TwoWay));
                resultado.SetBinding(Label.TextProperty, new Binding("Resultado", BindingMode.OneWay));

                panel.Children.Add(botonSencillo = new Button
                {
                    Text = "Ejemplo Command",
                });

                panel.Children.Add(texto = new Label
                {
                    Text = "Texto a mostrar",
                });

                botonSencillo.SetBinding(Button.CommandProperty, "SimpleCommand");
                texto.SetBinding(Label.TextProperty, new Binding("Texto", BindingMode.OneWay));


                panel.Padding = new Thickness(20, Device.OnPlatform(40,20,20) ,20,20);

                this.Content = panel;
            }

        }
    }
}
