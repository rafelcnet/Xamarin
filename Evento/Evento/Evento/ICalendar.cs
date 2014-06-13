using System;

namespace Evento
{
    public interface ICalendar
    {
        void AddEvent(string Titulo, string Lugar, DateTime Inicio, DateTime Termina, string Descripcion);
    }
}
