using ShopPrint_Aplicativo.Classes;
using ShopPrint_Aplicativo.Listas;
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
    }
}