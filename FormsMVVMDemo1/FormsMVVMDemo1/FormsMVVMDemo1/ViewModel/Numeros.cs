using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsMVVMDemo1
{
    public class Numeros : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string numero1;

        public string Numero1
        {
            get { return numero1; }
            set {
                numero1 = value;
                OnPropertyChanged("Numero1");
                OnPropertyChanged("Resultado");
            }
        }

        private string numero2;

        public string Numero2
        {
            get { return numero2; }
            set
            {
                numero2 = value;
                OnPropertyChanged("Numero2");
                OnPropertyChanged("Resultado");
            }
        }

        private string numero3;

        public string Numero3
        {
            get { return numero3; }
            set
            {
                numero3 = value;
                OnPropertyChanged("Numero3");
                OnPropertyChanged("Resultado");
            }
        }
        public string Resultado
        {
            get
            {
                try
                {
                    return (Int32.Parse(Numero1) + Int32.Parse(Numero2) + Int32.Parse(Numero3)).ToString();
                }
                catch (Exception)
                {
                    return "0";
                }
            }
        }

        // agregado para comandos
        private string texto;

        public string Texto
        {
            get { return texto; }
            set
            {
                texto = value;
                OnPropertyChanged("Texto");
            }
        }

        public void MostrarMensaje()
        {
            Texto = "Hola";
        }

        private Command simpleCommand;
        public Command SimpleCommand
        {
            get
            {
                return simpleCommand ?? (simpleCommand = new Command(x => MostrarMensaje()));
            }
        }

       
    }
}
