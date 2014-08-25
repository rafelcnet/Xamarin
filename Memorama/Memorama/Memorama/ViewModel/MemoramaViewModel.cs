using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Memorama
{
    public class MemoramaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Carta> MemoryCardList;
        Random random = new Random();
        List<string> icons;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int nivel;

        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; OnPropertyChanged("Nivel"); }
        }

        private int tiradas;

        public int Tiradas
        {
            get { return tiradas; }
            set
            {
                tiradas = value;
                OnPropertyChanged("Tiradas");
            }
        }

        private int pares;

        public int Pares
        {
            get { return pares; }
            set
            {
                pares = value;
                OnPropertyChanged("Pares");
            }
        }

        private int cardSize = 100;

        /// <summary>
        /// Gets the CardSize property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CardSize
        {
            get { return cardSize; }

            set
            {
                if (cardSize == value)
                    return;
                cardSize = value;
                OnPropertyChanged("CardSize");
            }
        }

        private int cardCount;

        public int CardCount
        {
            get { return cardCount; }
            set
            {
                cardCount = value;
                OnPropertyChanged("CardCount");
            }
        }

        private bool primerClick;

        public bool PrimerClick
        {
            get { return primerClick; }
            set { primerClick = value; OnPropertyChanged("PrimerClick"); OnPropertyChanged("MemoryCardList"); }
        }

        private bool segundoClick;

        public bool SegundoClick
        {
            get { return segundoClick; }
            set { segundoClick = value; OnPropertyChanged("SegundoClick"); OnPropertyChanged("MemoryCardList"); }
        }

        private int carta1;

        public int Carta1
        {
            get { return carta1; }
            set { carta1 = value; OnPropertyChanged("Carta1"); }
        }

        private int carta2;

        public int Carta2
        {
            get { return carta2; }
            set { carta2 = value; OnPropertyChanged("Carta2"); }
        }

        private bool terminado;

        public bool Terminado
        {
            get { return terminado; }
            set { terminado = value; OnPropertyChanged("Terminado"); }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged("Status"); }
        }


        private Command barajaCartasCommand;
        public Command BarajaCartasCommand
        {
            get
            {
                return barajaCartasCommand ?? (barajaCartasCommand = new Command(ExecuteBarajaCartasCommand));
                //return barajaCartasCommand ?? (barajaCartasCommand = new Command(async () => await ExecuteLoadReciboCommand()));
            }
        }

        public void ExecuteBarajaCartasCommand()
        {
            switch (Nivel)
            {
                case 0:
                    cardCount = 6;
                    CardSize = 136;
                    break;
                case 1:
                    cardCount = 10;
                    CardSize = 100;
                    break;
            }

            icons = new List<string>();
            for (int i = 0; i < CardCount; i++)
            {
                icons.Add("imagen" + i.ToString() + ".png");
                icons.Add("imagen" + i.ToString() + ".png");
            }

            for (int i = 0; i < CardCount * 2; i++)
            {
                int randomNumber = random.Next(icons.Count);
                Carta carta = new Carta(icons[randomNumber], i);
                icons.RemoveAt(randomNumber);
                if (MemoryCardList.Count == i)
                    MemoryCardList.Add(carta);
                else
                    MemoryCardList[i].ImagenAbierta = carta.ImagenAbierta;
                MemoryCardList[i].ID = i;
            }
            Terminado = false;
            Pares = Tiradas = 0;
            primerClick = false;
            segundoClick = false;
            Status = "En espera...";
            ExecuteCierraCartasCommand();
        }

        private Command cierraCartasCommand;

        public Command CierraCartasCommand
        {
            get { return cierraCartasCommand ?? (cierraCartasCommand = new Command(ExecuteCierraCartasCommand)); }

        }

        private void ExecuteCierraCartasCommand()
        {
            for (int i = 0; i < CardCount * 2; i++)
            {
                MemoryCardList[i].Abierta = false;
                MemoryCardList[i].ConPar = false;
                MemoryCardList[i].Seleccionada = false;
                MemoryCardList[i].Imagen = "cartaCerrada.png";
            }
        }

        private Command seleccionaCartaCommand;

        public Command SeleccionaCartaCommnad
        {
            get { return seleccionaCartaCommand ?? (seleccionaCartaCommand = new Command<int>(ExecuteSeleccionaCartaCommand)); }
        }

        private void ExecuteSeleccionaCartaCommand(int indCarta)
        {
            if (Terminado) return;
            Status = "Jugando...";
            //Ya tiene par?
            if (MemoryCardList[indCarta].ConPar)
                return;
            // ya está abierta la cierra
            if (MemoryCardList[indCarta].Seleccionada)
            {
                //CierraCarta(boton);
                MemoryCardList[indCarta].Imagen = "cartaCerrada.png";
                MemoryCardList[indCarta].Seleccionada = false;
                if (SegundoClick)
                {
                    SegundoClick = false;
                    Carta2 = 0;
                    return;
                }

                if (primerClick)
                {
                    Carta1 = 0;
                    PrimerClick = false;
                    return;
                }
            }

            if (PrimerClick && SegundoClick)
                return;
            //No está seleccionada, la abre y verifica si es primer o segundo click
            MemoryCardList[indCarta].Seleccionada = true;
            MemoryCardList[indCarta].Imagen = MemoryCardList[indCarta].ImagenAbierta;
            if (primerClick)
            {
                Carta2 = MemoryCardList[indCarta].ID;
                SegundoClick = true;
                Tiradas++;
                // verifica si son pares
                if (MemoryCardList[carta1].Imagen == MemoryCardList[carta2].ImagenAbierta)
                {
                    MemoryCardList[indCarta].ConPar = true;
                    Pares++;
                    if (Pares == CardCount)
                    {
                        Terminado = true;
                        Status = "Terminado, encontraste los pares!";
                        return;
                    }
                    Carta1 = 0;
                    Carta2 = 0;
                    PrimerClick = false;
                    SegundoClick = false;
                }
            }
            else
            {
                Carta1 = MemoryCardList[indCarta].ID;
                Carta2 = 0;
                PrimerClick = true;
                SegundoClick = false;
            }
        }

        public MemoramaViewModel()
        {
            MemoryCardList = new ObservableCollection<Carta>();
        }
    }
}
