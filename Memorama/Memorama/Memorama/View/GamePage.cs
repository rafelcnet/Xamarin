using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Memorama
{
    public class GamePage : ContentPage
    {
        private MemoramaViewModel ViewModel
        {
            get { return BindingContext as MemoramaViewModel; }
        }
        public GamePage(int nivel, double width)
        {
            BindingContext = new MemoramaViewModel();
            App.Width = width;
            ViewModel.Nivel = nivel;
            ViewModel.ExecuteBarajaCartasCommand();
            Title = ViewModel.CardCount.ToString() + " pares";
            BackgroundColor = Color.White;

            var refresh = new Button
            {
                Command = ViewModel.BarajaCartasCommand,
                Text = "Barajar de nuevo",
                TextColor = Color.White,
                BorderColor = Color.Green,
                BackgroundColor = Color.Green,
                WidthRequest = 140,
                HeightRequest = 60
            };

            StackLayout panel = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 6,
                Padding = new Thickness(20, Device.OnPlatform(10, 20, 20), 20, Device.OnPlatform(10, 20, 20)),
            };
            panel.Children.Add(new Label
            {
                Text = "juego de memoria",
                TextColor = Color.Gray,
                Font = Font.SystemFontOfSize(Device.OnPlatform(30, 30, 50))
            });

            StackLayout stats = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
                HeightRequest = 40,
                Spacing = 4
            };
            stats.Children.Add(new Label
            {
                Text = "Movimientos:",
                TextColor = Color.Green,
            });

            Label movtos = new Label
            {
                WidthRequest = 30,
                Text = "0",
                TextColor = Color.Red
            };
            movtos.SetBinding(Label.TextProperty, new Binding("Tiradas", BindingMode.OneWay, new StringConverter()));
            stats.Children.Add(movtos);
            stats.Children.Add(new Label
            {
                Text = "Pares:",
                TextColor = Color.Green,
            });

            Label pares = new Label
            {
                WidthRequest = 30,
                Text = "0",
                TextColor = Color.Red
            };
            pares.SetBinding<MemoramaViewModel>(Label.TextProperty, vm => vm.Pares, BindingMode.OneWay, new StringConverter());
            stats.Children.Add(pares);
            panel.Children.Add(stats);

            StackLayout status = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 4,
            };
            status.Children.Add(new Label
            {
                Text = "Estado:",
                TextColor = Color.Green,
            });

            Label estado = new Label
            {
                WidthRequest = 340,
                Text = "",
                TextColor = Color.Red
            };
            estado.SetBinding(Label.TextProperty, "Status");
            status.Children.Add(estado);
            panel.Children.Add(status);

            if (ViewModel.Nivel == 0)
            {
                var cartas = new Grid6Cartas(ViewModel);
                panel.Children.Add(cartas);
            }
            else if (ViewModel.Nivel == 1)
            {
                var cartas = new Grid10Cartas(ViewModel);
                panel.Children.Add(cartas);
            }
            panel.Children.Add(refresh);

            var scrollview = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = ScrollOrientation.Vertical,
                HeightRequest = App.Height,
                Content = panel
            };

            Content = scrollview;
        }
    }

    public class Grid6Cartas : Grid
    {
        public Grid6Cartas(MemoramaViewModel ViewModel)
        {
            double ancho = App.Width / 3;
            if (Device.Idiom == TargetIdiom.Tablet)
                ViewModel.CardSize = (int)Device.OnPlatform((ancho * .6), (ancho * 1.3), (ancho * 1.3));
            else
                ViewModel.CardSize = (int)Device.OnPlatform((ancho * .8), (ancho * 1.2), (ancho * 1.2));

            RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = new GridLength(ancho, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(ancho, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(ancho, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(ancho, GridUnitType.Absolute) }
                };
            ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(ancho, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(ancho, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(ancho, GridUnitType.Absolute) }
                };

            int col = 0;
            int ren = 0;
            for (int i = 0; i < ViewModel.CardCount * 2; i++)
            {
                if (ren == 3)
                {
                    ren = 0;
                    col++;
                }
                var imgTmp = new ImageButton
                {
                    BackgroundColor = Color.White,
                    BorderWidth = 0,
                    BorderColor = Color.White,
                    BindingContext = ViewModel.MemoryCardList[i],
                    Command = ViewModel.SeleccionaCartaCommnad,
                    CommandParameter = i,
                    Orientation = ImageOrientation.ImageToLeft,
                    ImageWidthRequest = ViewModel.CardSize,
                    ImageHeightRequest = ViewModel.CardSize
                };
                imgTmp.SetBinding(ImageButton.SourceProperty, new Binding("Imagen", BindingMode.OneWay, new ImageConverter()));
                Children.Add(imgTmp, ren, col);
                ren++;
            }

        }
    }
    public class Grid10Cartas : Grid
    {
        public Grid10Cartas(MemoramaViewModel ViewModel)
        {
            double ancho = App.Width / 4;
            ViewModel.CardSize = (int)Device.OnPlatform((ancho * .6), (ancho * 1.3), (ancho * 1.3));

            RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = new GridLength(ancho, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(ancho, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(ancho, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(ancho, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(ancho, GridUnitType.Absolute) }
                };
            ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(ancho, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(ancho, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(ancho, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(ancho, GridUnitType.Absolute) }
                };

            int col = 0;
            int ren = 0;
            for (int i = 0; i < ViewModel.CardCount * 2; i++)
            {
                if (col == 4)
                {
                    col = 0;
                    ren++;
                }
                var imgTmp = new ImageButton
                {
                    BackgroundColor = Color.White,
                    BorderWidth = 0,
                    BorderColor = Color.White,
                    BindingContext = ViewModel.MemoryCardList[i],
                    Command = ViewModel.SeleccionaCartaCommnad,
                    CommandParameter = i,
                    Orientation = ImageOrientation.ImageToLeft,
                    ImageWidthRequest = ViewModel.CardSize,
                    ImageHeightRequest = ViewModel.CardSize
                };
                imgTmp.SetBinding(ImageButton.SourceProperty, new Binding("Imagen", BindingMode.OneWay, new ImageConverter()));
                Children.Add(imgTmp, col, ren);
                col++;
            }

        }
    }
}
