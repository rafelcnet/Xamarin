using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyOutSample
{
  public class AplicacionesViewModel : BaseViewModel
  {
    public ObservableCollection<Aplicacion> ListaAplicaciones { get; set; }

    public AplicacionesViewModel()
    {
      ListaAplicaciones = new ObservableCollection<Aplicacion>();
      ListaAplicaciones.Add(new Aplicacion { EsHeader = true, ColorFondo= "B4BCBC", Imagen= "", Nombre = "Opciones"  });
      ListaAplicaciones.Add(new Aplicacion { EsHeader = false, ColorFondo = "FFFFFF", Imagen = "house.png", Nombre = "Inicio" });
      ListaAplicaciones.Add(new Aplicacion { EsHeader = false, ColorFondo = "FFFFFF", Imagen = "iconosclubes.png", Nombre = "Clubes" });
      ListaAplicaciones.Add(new Aplicacion { EsHeader = false, ColorFondo = "FFFFFF", Imagen = "iconosclases.png", Nombre = "Clases" });
      ListaAplicaciones.Add(new Aplicacion { EsHeader = false, ColorFondo = "FFFFFF", Imagen = "iconosherramientas.png", Nombre = "Herramientas" });
      ListaAplicaciones.Add(new Aplicacion { EsHeader = true, ColorFondo = "B4BCBC", Imagen = "", Nombre = "Soporte" });
      ListaAplicaciones.Add(new Aplicacion { EsHeader = false, ColorFondo = "FFFFFF", Imagen = "info.png", Nombre = "Acerca de" });

      Icon = "slideout.png";
    }

  }
}
