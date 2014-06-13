using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Evento.Android;
using Xamarin.Forms;

[assembly: Dependency(typeof(CalendarDroid))]

namespace Evento.Android
{
    public class CalendarDroid : ICalendar 
    {

        public void AddEvent(string Titulo, string Lugar, DateTime Inicio, DateTime Termina, string Descripcion)
        {
            var intent = new Intent(Intent.ActionEdit);
            intent.SetType("vnd.android.cursor.item/event");
            intent.PutExtra("title", Titulo);
            intent.PutExtra("beginTime", TimeInMillis(Inicio));
            intent.PutExtra("beginTime", TimeInMillis(Termina));
            intent.PutExtra("descruption", Descripcion);
            intent.PutExtra("eventLocation", Lugar);
            intent.PutExtra("allDay", false);
            intent.AddFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
        }

        private readonly static DateTime jan1970 = new DateTime(1970, 1, 1, 0 ,0,0, DateTimeKind.Utc);
        private static Int64 TimeInMillis(DateTime dateTime)
        {
            return (Int64)(dateTime.AddHours(6) - jan1970).TotalMilliseconds; 
        }

        public CalendarDroid() { }
    }
}