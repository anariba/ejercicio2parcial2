using Ejercicio2parcial2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2parcial2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowSignatureInformation : ContentPage
    {
        public ShowSignatureInformation(Firmas firma)
        {
            InitializeComponent();
            name.Text = firma.nombre;
            description.Text = firma.Descrip;
            imageSignature.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(firma.firma)));
        }
    }
}