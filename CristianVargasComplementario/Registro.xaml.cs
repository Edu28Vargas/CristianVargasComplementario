
using CristianVargasComplementario.Models;
using SQLite;
using System;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CristianVargasComplementario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Registro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var DatosRegistros = new ESTUDIANTES_LOGIN {Usuario = Convert.ToInt32( txtUsuario.Text), Contrasena = txtContrasena.Text };
            _conn.InsertAsync(DatosRegistros);
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            DisplayAlert("Exito", "Se agrego correctamente", "Cerrar");
        }



    }
}