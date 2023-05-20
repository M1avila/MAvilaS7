using System;
using System.Collections.Generic;
using System.Text;
using SQLite;//utilizar los metodos de la base de datos

namespace MAvilaS7
{
    public interface DataBase
    {
    //creamos el metodo
    SQLiteAsyncConnection GetConnection();//define el metodo de coneccion

    }
}
