using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento
{
    class EventoData : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        //

        private List<Speaker> speakers;
        public List<Speaker> Speakers {
            get { return speakers;  }
            set {
                speakers = value;
                OnPropertyChanged("Speakers");
            }
        }

        private List<Session> sessions;
        public List<Session> Sessions
        {
            get { return sessions; }
            set
            {
                sessions = value;
                OnPropertyChanged("Sessions");
            }
        }

        public EventoData() {
            Speakers = SpeakerData;
            Sessions = SessionData;
        }

        public List<Speaker> SpeakerData = new List<Speaker>() {
			new Speaker { Nombre = "Rafael Cárdenas", Empresa = "DCTIPN", Foto = "rafaelc.jpg", Twitter ="rafaelc" },
			new Speaker { Nombre = "John Zablocki", Empresa = "Couchbase", Foto = "john_zablocki.jpg", Twitter ="codevoyeur" },
			new Speaker { Nombre = "Miguel de Icaza", Empresa = "Xamarin", Foto = "miguel.jpg", Twitter ="migueldeicaza"},
			new Speaker { Nombre = "Aaron Bockover", Empresa = "Xamarin", Foto = "aaron.jpg", Twitter ="abock" },
			new Speaker { Nombre = "John Bubriski", Empresa = "", Foto = "john_bubriski.jpg", Twitter ="johnbubriski" },
			new Speaker { Nombre = "Paul Betts", Empresa = "Github", Foto = "paul.jpg", Twitter ="xpaulbettsx" },
			new Speaker { Nombre = "Louis DeJardin", Empresa = "Microsoft", Foto = "louis.jpg", Twitter ="loudej" },
			new Speaker { Nombre = "Scott Olson", Empresa = "", Foto = "scott.jpg", Twitter ="vagabondrev" },
			new Speaker { Nombre = "Igor Moochnick", Empresa = "", Foto = "igor.jpg", Twitter ="igor_moochnick" },
			new Speaker { Nombre = "Jérémie Laval", Empresa = "Xamarin", Foto = "jeremie.jpg", Twitter ="jeremie_laval" },
			new Speaker { Nombre = "Ananth Balasubramaniam", Empresa = "", Foto = "ananth.jpg", Twitter ="ananthonline" },
			new Speaker { Nombre = "Bob Familiar", Empresa = "Microsoft", Foto = "bob.jpg", Twitter ="bobfamiliar" },
			new Speaker { Nombre = "Michael Hutchinson", Empresa = "Xamarin", Foto = "michael.jpg", Twitter ="mjhutchinson" },
			new Speaker { Nombre = "Jonathan Chambers", Empresa = "Unity", Foto = "jonathan.jpg", Twitter ="jon_cham" },
			new Speaker { Nombre = "Steve Millar", Empresa = "Infinitek", Foto = "steve.jpg", Twitter ="samillar77" },
			new Speaker { Nombre = "Somya Jain", Empresa = "", Foto = "somya.jpg", Twitter ="somya_j" },
			new Speaker { Nombre = "Sam Lippert", Empresa = "", Foto = "sam.jpg", Twitter ="lippertz" },
			new Speaker { Nombre = "Don Syme", Empresa = "Microsoft", Foto = "don.jpg", Twitter ="dsyme" },
			new Speaker { Nombre = "Dean Ellis", Empresa = "Aurora", Foto = "dean.jpg", Twitter ="infspacestudios" },
			new Speaker { Nombre = "Jb Evain", Empresa = "SyntaxTree", Foto = "jb.jpg", Twitter ="jbevain" },
			new Speaker { Nombre = "Chris Hardy", Empresa = "Xamarin", Foto = "chris.jpg", Twitter ="chrisntr" },
			new Speaker { Nombre = "Demis Bellot", Empresa = "StackExchange", Foto = "demis.jpg", Twitter ="demisbellot" },
			new Speaker { Nombre = "Frank Krueger", Empresa = "Xamarin", Foto = "frank.jpg", Twitter ="praeclarum" },
			new Speaker { Nombre = "Greg Shackles", Empresa = "OLO", Foto = "greg.jpg", Twitter ="gshackles" },
			new Speaker { Nombre = "Phil Haack", Empresa = "Github", Foto = "phil.jpg", Twitter ="haacked" },
			new Speaker { Nombre = "David Fowler", Empresa = "Microsoft", Foto = "david.jpg", Twitter ="davidfowler" },
		};

        public List<Session> SessionData = new List<Session>() {
			new Session {
				Titulo = "Xamarin.Forms y MVVM",
				Speaker = "Rafael Cárdenas",
				Lugar = "Ballroom",
				Resumen = "Esta sesión explica el uso de patrón de diseño MVVM (Model View ViewModel) y cómo implementarlo en Xamarin Forms, para desarrollar aplicaciones en 3 plataformas.",
				Inicia = new DateTime (2014, 6, 14, 9, 0, 0),
				Termina = new DateTime (2014, 6, 14, 11, 0, 0)
			},
			new Session {
				Titulo = "Introduction to Mobile Development",
				Speaker = "Bryan Costanich",
				Lugar = "Ballroom",
				Inicia = new DateTime (2014, 6, 14, 9, 0, 0),
				Termina = new DateTime (2014, 6, 14, 11, 0, 0)
			},
			new Session {
				Titulo = "Hello iOS",
				Speaker = "Bryan Costanich",
				Lugar = "Ballroom",
				Inicia = new DateTime (2014, 6, 14, 10, 0, 0),
				Termina = new DateTime (2014, 6, 14, 12, 0, 0)
			},
			new Session {
				Titulo = "Hello Android",
				Speaker = "Bryan Costanich",
				Lugar = "Ballroom",
				Inicia = new DateTime (2014, 6, 14, 15, 0, 0)
			},
			new Session {
				Titulo = "Cross-platform Navigation",
				Speaker = "Bryan Costanich",
				Lugar = "Ballroom",
				Inicia = new DateTime (2013, 4, 15, 9, 0, 0)
			},
			new Session {
				Titulo = "Cross-platform Projects",
				Speaker = "Bryan Costanich",
				Lugar = "Ballroom",
				Inicia = new DateTime (2013, 4, 15, 9, 0, 0)
			},
			new Session {
				Titulo = "Keynote (Day 1)",
				Speaker = "Miguel de Icaza, Nat Friedman",
				Lugar = "Ballroom",
				Inicia = new DateTime (2013, 4, 16, 9, 0, 0)
			},
			new Session {
				Titulo = "Keynote (Day 2)",
				Speaker = "Miguel de Icaza, Nat Friedman",
				Lugar = "Ballroom",
				Inicia = new DateTime (2013, 4, 17, 9, 0, 0)
			},
		};

    }
}
