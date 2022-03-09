using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;
using Ejercicio2parcial2.Models;
using Ejercicio2parcial2.Views;

namespace Ejercicio2parcial2
{
    public partial class MainPage : ContentPage
    {
        String bs64;
        public byte[] imageByte;
        public MainPage()
        {
            InitializeComponent();
        }

        public async void convertir()
        {
             Stream img = await Firma.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            var mStream = (MemoryStream)img;


            BinaryReader br = new BinaryReader(img);

             imageByte = br.ReadBytes((Int32)img.Length);

             bs64 = Convert.ToBase64String(imageByte, 0, imageByte.Length);

            if (String.IsNullOrWhiteSpace(txnombre.Text) || String.IsNullOrWhiteSpace(txdescrip.Text))
            {
                await DisplayAlert("Error", "Se deben llenar los campos de nombre y descripcion", "Aceptar");
            }


            //  imgSignature.Source = ImageSource.FromStream(() => mStream);


        }
        private async void GuardarFirma_Clicked(object sender, EventArgs e)
        {
            convertir();


            var firma = new Models.Firmas

            {
                firma = bs64,
                nombre = txnombre.Text,
                Descrip = txdescrip.Text

            };


            var resultado = await App.DB.guardar(firma);

            if (resultado != 0)
                await DisplayAlert("Aviso", "Ingresado con exito", "OK");
            else
                await DisplayAlert("Aviso", "Error", "OK");
        }

    

        private  void BtnLista_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new SignaturesList());


        }
    }
}
