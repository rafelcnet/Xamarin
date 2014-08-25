using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama
{
    public class Carta : INotifyPropertyChanged
    {
        string imagen;
        public string Imagen
        {
            get { return imagen; }

            set
            {
                imagen = value;
                OnPropertyChanged("Imagen");
            }
        }
        public string ImagenCerrada { get; set; }
        public string ImagenAbierta { get; set; }
        public bool Abierta { get; set; }
        public bool Seleccionada { get; set; }
        public bool ConPar { get; set; }
        public int ID { get; set; }

        public Carta()
        {
        }

        public Carta(string imagenAbierta, int id)
        {
            ImagenAbierta = imagenAbierta;
            Abierta = false;
            ImagenCerrada = Imagen = "cartaCerrada.png";
            Seleccionada = false;
            ConPar = false;
            ID = id;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
