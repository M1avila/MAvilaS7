using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite; //se agrega
using Xamarin.Forms.Xaml;
using System.IO; //se agrega
using MAvilaS7.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ClienteAndroid))]

namespace MAvilaS7.Droid
{
    public class ClienteAndroid:DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            //ruta haci la db
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var BaseDatos = Path.Combine(ruta, "uisrael.db3");
            return new SQLiteAsyncConnection(BaseDatos);
        }
    }
}