using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAvilaS7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<Estudiante> tablaEstudiantes;
        public ConsultaRegistro()
        {
            InitializeComponent();
            conexion= DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);//para ocultar la flecha de navegacion
            ObtenerEstudiantes();

        }
        public async void ObtenerEstudiantes()
        {
            var ResulEstudiantes= await conexion.Table<Estudiante>().ToListAsync();
            tablaEstudiantes = new ObservableCollection<Estudiante>(ResulEstudiantes);
            listaEstudiantes.ItemsSource = tablaEstudiantes;

        }
        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var ObjetoEstudiante = (Estudiante)e.SelectedItem;
            var ItemId=ObjetoEstudiante.Id.ToString();
            int id = Convert.ToInt32(ItemId); //id
            string nombre= ObjetoEstudiante.Nombre.ToString();
            string usuario= ObjetoEstudiante.Usuario.ToString();
            string contrasena=ObjetoEstudiante.Contrasena.ToString();

            Navigation.PushAsync(new Elemento(id, nombre, usuario, contrasena));
        }

        private void btbSalir_Clicked(object sender, EventArgs e)
        {
            //para salir
            var ObjetoEstudiante = (new Login());
        }
    }
}