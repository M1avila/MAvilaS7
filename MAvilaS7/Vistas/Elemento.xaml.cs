using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;//agrega
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace MAvilaS7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        //creo las variables
        public int idSelecionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<Estudiante> RActualizar;
        IEnumerable<Estudiante> REliminar;

        public Elemento(int id, string nombre, string usuario, string contrsena)
        {
            InitializeComponent();
            txtID.Text= id.ToString();
            txtNombre.Text= nombre;
            txtUsuario.Text= usuario;
            txtContrasena.Text= contrsena;
            //inicializo las variables
            conexion = DependencyService.Get<DataBase>().GetConnection();
            idSelecionado = id;
        }
        //creando metodos para eliminar
        public static IEnumerable<Estudiante> Eliminar(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where id=?", id);
        }
        //metodo para actualizar
        public static IEnumerable<Estudiante>Actualizar(SQLiteConnection db, string nombre, string usuario, string contrsena, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante set Nombre=?, Usuario=?, Contrasena=? where  id=?", nombre, usuario, contrsena, id);
        }
        private void btnActulalizar_Clicked(object sender, EventArgs e)
        {
            //actualizar
            //creo 3 variables
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                RActualizar = Actualizar(db, txtNombre.Text, txtUsuario.Text, txtContrasena.Text, idSelecionado);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {

                DisplayAlert("ALERTA", ex.Message, "CERRAR");
            }
                   
                  
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                REliminar = Eliminar(db, idSelecionado);
                Navigation.PushAsync(new ConsultaRegistro());


            }
            catch (Exception ex)
            {

                DisplayAlert("ALERTA",ex.Message, "cerrar");
            }

        }
    }
}