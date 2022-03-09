using Ejercicio2parcial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2parcial2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignaturesList : ContentPage
    {
        public SignaturesList()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            base.OnAppearing();
            LoadCollectionView();
        }

        private async void LoadCollectionView()
        {
            listSignatures.ItemsSource = await App.DB.ListaFirma();
        }

        private async void listSignatures_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (Firmas)e.SelectedItem;

            var signatureObtained = await App.DB.GetSignatureByCode(itemSelected.Id);

            var showSignatureInformationPage = new ShowSignatureInformation(signatureObtained);

            await Navigation.PushAsync(showSignatureInformationPage);
        }
    }
}