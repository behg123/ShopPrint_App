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
	public partial class AboutusPage : ContentPage
	{
		public AboutusPage ()
		{
			InitializeComponent ();
		}
        private async void CartClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CartPage());
        }
    }
}