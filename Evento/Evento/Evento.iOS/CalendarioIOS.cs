using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;
using Evento.iOS;
using MonoTouch.EventKit;

[assembly: Dependency (typeof (CalendarioIOS))]

namespace Evento.iOS
{
    public class CalendarioIOS : ICalendar
    {
        public void AddEvent(string Titulo, string Lugar, DateTime Inicio, DateTime Termina, string Descripcion)
        {
            try
            {
                EKEventStore evStore = new EKEventStore();
                evStore.RequestAccess(EKEntityType.Event, (bool granted, NSError e) => {
                    if (!granted)
                        new UIAlertView("Acceso denegado", "El usuario no permite acceso al calendario", null, "ok", null).Show();
                });
                EKCalendar calendar = evStore.DefaultCalendarForNewEvents;
                NSPredicate evPredicate = evStore.PredicateForEvents(Inicio, Termina, evStore.GetCalendars(EKEntityType.Event));
                bool encontrado = false;

                evStore.EnumerateEvents(evPredicate, delegate(EKEvent calEvent, ref bool stop) {
                    if (calEvent.Title == Titulo)
                        encontrado = true;
                });
                if (encontrado)
                {
                    new UIAlertView("Evento", "El evento ya existe en el calendario", null, "ok", null).Show();
                }
                else
                {
                    EKEvent newEvent = EKEvent.FromStore(evStore);
                    newEvent.Title = Titulo;
                    newEvent.Notes = Descripcion;
                    newEvent.Calendar = calendar;
                    newEvent.StartDate = Inicio;
                    newEvent.EndDate = Termina;
                    newEvent.Location = Lugar;
                    var error = new NSError(new NSString(""), 0);
                    evStore.SaveEvent(newEvent, EKSpan.ThisEvent, out error);
                    if(error.LocalizedDescription!="")
                        new UIAlertView("Evento", "Hubo un problema al agregar el evento " + error.LocalizedDescription, null, "ok", null).Show();
                    else
                        new UIAlertView("Evento", "El evento se agregó a su calendario", null, "ok", null).Show();
                }
            }
            catch (Exception) {
                new UIAlertView("Evento", "Hubo un problema al agregar el evento", null, "ok", null).Show();
            }
            
        }
    }
}