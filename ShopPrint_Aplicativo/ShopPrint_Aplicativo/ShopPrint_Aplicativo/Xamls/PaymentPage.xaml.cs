using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopPrint_Aplicativo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentPage : ContentPage
    {
        public PaymentPage()
        {
            InitializeComponent();
        }
        private async void CartClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CartPage());
        }

        public void OnButtonClicked(object sender, EventArgs args) {
            DisplayAlert("Desculpe", "Essa funcionalidade ainda não foi implementada", "OK");
        }
    }
}