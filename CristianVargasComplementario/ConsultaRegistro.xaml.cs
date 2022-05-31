
using CristianVargasComplementario.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CristianVargasComplementario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Estudiante> _TablaEstudiante;

        public ConsultaRegistro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);

        }

        protected async override void OnAppearing()
        {
            var resultadoRegistros = await _conn.Table<Estudiante>().ToArrayAsync();
            _TablaEstudiante = new ObservableCollection<Estudiante>(resultadoRegistros);
            ListaUsuario.ItemsSource = _TablaEstudiante;
            base.OnAppearing();
        }
        private async void ListaUsuario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var iten = obj.Id.ToString();
            int id = Convert.ToInt32(iten);
            try
            {
                await Navigation.PushAsync(new Elemento(obj));

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}