using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Evento
{
    public class SpeakerDetailPage : ContentPage
    {

        public SpeakerDetailPage(){
            NavigationPage.SetHasNavigationBar(this, true);
            BackgroundColor = Color.White;

            var nameLabel = new Label { TextColor = Color.Gray };
            nameLabel.SetBinding(Label.TextProperty, new Binding("Nombre"));

            var empresaLabel = new Label { TextColor = Color.Gray };
            empresaLabel.SetBinding(Label.TextProperty, new Binding("Empresa"));

            var twitterLabel = new Label { TextColor = Color.Gray };
            twitterLabel.SetBinding(Label.TextProperty, new Binding("Twitter"));

            var fotoImage = new Image ();
            fotoImage.SetBinding(Image.SourceProperty, new Binding("Foto"));

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = 10,
                Children = { 
                    nameLabel,
                    empresaLabel,
                    twitterLabel,
                    fotoImage
                }
            };

        }

    }
}
