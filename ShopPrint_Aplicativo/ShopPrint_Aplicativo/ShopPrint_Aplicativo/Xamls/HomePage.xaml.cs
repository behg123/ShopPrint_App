using ShopPrint_Aplicativo.Listas;
using ShopPrint_Aplicativo.Xamls;
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
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            BindingContext = new ListPage();

        }
        private async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ProductPage());
        }
        
        private async void CartClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync (new CartPage());
        }

    }
}