using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio2parcial2.Controller;
using System.IO;
using Ejercicio2parcial2.Models;

namespace Ejercicio2parcial2
{
    public partial class App : Application

    {
        static FirmaController basedatos;

        public static FirmaController DB
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new FirmaController(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FirmaController.db3"));
                }
                return basedatos;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
          //  MainPage = new MainPage();
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
