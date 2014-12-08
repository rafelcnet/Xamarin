using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlyOutSample
{
  public class MasterMainView : MasterDetailPage
  {
    private AplicacionesViewModel ViewModel
    {
      get { return BindingContext as AplicacionesViewModel; }
    }

    public MasterMainView()
    {
      BindingContext = new AplicacionesViewModel();

      Image logo = new Image
      {
        Source = "iconapp.png"
      };

      Label header = new Label
      {
        Text = "Pemex H&F",
        TextColor = Color.Black,
        Font = Font.SystemFontOfSize(22),
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.Center
      };

      var Cabecera = new StackLayout
      {
        Spacing = 4,
        BackgroundColor = Color.White,
        Orientation = StackOrientation.Horizontal,
        Children = { logo, header }
      };

      ScrollView contenedor = new ScrollView
      {
        VerticalOptions = LayoutOptions.FillAndExpand,
        Orientation = ScrollOrientation.Vertical
      };

      ListView listaOpciones = new ListView();
      listaOpciones.ItemsSource = ViewModel.ListaAplicaciones;
      listaOpciones.ItemTemplate = new DataTemplate(typeof(OpcionesCell));
      listaOpciones.RowHeight = Device.OnPlatform(28, 28, 36);

      listaOpciones.ItemSelected += listaOpciones_ItemSelected;

      contenedor.Content = new StackLayout
      {
        BackgroundColor = Color.White,
        Children = 
              {
                  Cabecera, listaOpciones
              }
      };

      this.Master = new ContentPage
      {
        BackgroundColor = Color.White,
        Title = "=",
        Padding = new Thickness(10, Device.OnPlatform(30, 15, 15), 10, 10),
        Content = contenedor
      };

      var detail = new NavigationPage(new AboutPage())
      {
        BarTextColor = Color.White,
        BarBackgroundColor = Color.Maroon
      };
      this.Detail = detail;
      Master.Icon = "slideout.png";
    }

    void listaOpciones_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
      NavigationPage detalle = null;

      var item = e.SelectedItem as Aplicacion;
      switch (item.Nombre)
      {
        case "Acerca de": detalle = new NavigationPage(new AboutPage()); break;
      }
      if (detalle == null) return;
      detalle.BarTextColor = Color.White;
      detalle.BarBackgroundColor = Color.Maroon;
      IsPresented = false;
      this.Detail = detalle;
    }
  }
}
