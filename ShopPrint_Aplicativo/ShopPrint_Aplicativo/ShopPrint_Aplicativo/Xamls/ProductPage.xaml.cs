using ShopPrint_Aplicativo.Listas;
using ShopPrint_Aplicativo.Xamls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopPrint_Aplicativo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductPage : ContentPage
    {
		public ProductPage ()
		{
			InitializeComponent ();
			BindingContext = new ListPage();
		}

		private async void OnItemSelected(object sender, ItemTappedEventArgs e)
		{
			var details = e.Item as Products;
			await Navigation.PushAsync(new DetailPage(details.Title, details.Url, details.Description, (details.Price).ToString()));
		}

        private async void CartClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CartPage());
        }

    }
}