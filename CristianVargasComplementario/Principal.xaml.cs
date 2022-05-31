using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CristianVargasComplementario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnVerLista_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultaRegistro());
        }

        private void btntNuevo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Elemento());
        }

        private void btnCamara_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Camara());
        }
    }
}