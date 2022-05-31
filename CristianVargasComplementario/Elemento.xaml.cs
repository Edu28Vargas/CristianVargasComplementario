
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
    public partial class Elemento : ContentPage
    {
        public Estudiante datos;
        private SQLiteAsyncConnection _conn;
        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadoUpdate;
        public Elemento()
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection();
            btnActualizar.Text = "Registrar";
        }
        public Elemento(Estudiante idDato)
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection();
            datos = idDato;
            txtNombre.Text = datos.Nombre;
            txtApellido.Text = datos.Apellido;
            txtCurso.Text = datos.Curso;
            txtParalelo.Text = datos.Paralelo;
            txtNota.Text = datos.Nota.ToString();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var path = Path.Combine(documentsPath, "DBESTUDIANTES.DB");
                var db = new SQLiteConnection(path);
                if (datos!=null && datos.Id>0)
                {
                    ResultadoDelete = Update(db, datos.Id, txtNombre.Text, txtApellido.Text, txtCurso.Text, txtParalelo.Text, Convert.ToDecimal(txtNota.Text));
                    DisplayAlert("Alerta", "Dato actualziado", "Cerrar");
                }
                else
                {
                    var DatosRegistros = new Estudiante
                    { 
                        Nombre = txtNombre.Text, 
                    Apellido = txtApellido.Text,
                    Curso = txtCurso.Text,
                    Paralelo=txtParalelo.Text,
                    Nota=Convert.ToDecimal( txtNota.Text)
                    };
                    _conn.InsertAsync(DatosRegistros);
                    DisplayAlert("Alerta", "Dato registrado", "Cerrar");

                }

               



            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");

            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {


            try
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var path = Path.Combine(documentsPath, "DBESTUDIANTES.DB");
                var db = new SQLiteConnection(path);
                ResultadoDelete = Delete(db, datos.Id);

                DisplayAlert("Alerta", "Dato eliminado", "Cerrar");



            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");

            }

        }


        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id=?", id);

        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, int id, string nombre, string apellido, string curso, string paralelo, decimal nota)
        {
            return db.Query<Estudiante>("Update  Estudiante set Nombre=?, Apellido=?, Curso=?,  Paralelo=?,  Nota=?  where Id=?", nombre, apellido, curso, paralelo, nota, id);

        }

    }
}