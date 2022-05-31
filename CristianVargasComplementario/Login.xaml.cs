using CristianVargasComplementario.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CristianVargasComplementario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _conn;

        public Login()
        {
            InitializeComponent();
            _conn = DependencyService.Get<SQLiteAsyncConnection>();
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var path = Path.Combine(documentsPath, "DBESTUDIANTES.DB");
                var db = new SQLiteConnection(path);
                db.CreateTable<ESTUDIANTES_LOGIN>();
                db.CreateTable<Estudiante>();
                IEnumerable<ESTUDIANTES_LOGIN> resultado = select_Where(db, Convert.ToInt32( txtUsuario.Text), txtContrasena.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new Principal());
                }
                else
                {
                    DisplayAlert("Alerta", "Verifique su usuario/contraseña", "Cerrar");
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");

            }
        }

        public static IEnumerable<ESTUDIANTES_LOGIN> select_Where(SQLiteConnection db, int usuario, string contrasena)
        {
            return db.Query<ESTUDIANTES_LOGIN>("select * from ESTUDIANTES_LOGIN where Usuario=? and Contrasena=?", usuario, contrasena);

        }
        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }
    }
}