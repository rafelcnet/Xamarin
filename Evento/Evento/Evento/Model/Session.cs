using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento
{
    public class Session
    {

        public string Speaker { get; set; }
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string Lugar { get; set; }

        public DateTime Inicia { get; set; }

        public DateTime Termina { get; set; }

        public Session() { }
    }
}
