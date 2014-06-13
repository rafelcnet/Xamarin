using Evento.WinPhone;
using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(CalendarioWP))]

namespace Evento.WinPhone
{
    class CalendarioWP : ICalendar
    {
        public void AddEvent(string Titulo, string Lugar, DateTime Inicio, DateTime Termina, string Descripcion)
        {
            SaveAppointmentTask appt = new SaveAppointmentTask();
            appt.Subject = Titulo;
            appt.Location = Lugar;
            appt.StartTime = Inicio;
            appt.EndTime = Termina;
            appt.Details = Descripcion;

            appt.Show();
        }
    }
}
