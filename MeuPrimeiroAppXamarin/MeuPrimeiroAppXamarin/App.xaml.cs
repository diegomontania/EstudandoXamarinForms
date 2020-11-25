using MeuPrimeiroAppXamarin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeuPrimeiroAppXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //inicia aplicação por essa 'view'
            MainPage = new NavigationPage(new ListagemView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
