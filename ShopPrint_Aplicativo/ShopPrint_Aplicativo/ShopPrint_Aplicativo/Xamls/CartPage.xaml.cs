using ShopPrint_Aplicativo.Classes;
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
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
            BindingContext = CartList.CartItemList;
            int Price = 0;
            foreach(Cart Item in CartList.CartItemList)
            {
                Price += Item.Price;
            }
            Preco.Text = Price.ToString();
        }

        private void AddQuantity(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Cart)button.BindingContext;
            item.Quantity += 1;
        }

        private void RemoveQuantity(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Cart)button.BindingContext;
            item.Quantity -= 1;
            if(item.Quantity == 0) {
                CartList.CartItemList.Remove(item);
            }
        }

        private void DeleteQuantity(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var item = (Cart)button.BindingContext;
            CartList.CartItemList.Remove(item);
        }

        private async void Checkout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckoutPage());
        }
    }
}