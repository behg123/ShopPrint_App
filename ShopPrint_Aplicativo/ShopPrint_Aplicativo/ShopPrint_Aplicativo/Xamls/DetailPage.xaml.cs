using ShopPrint_Aplicativo.Classes;
using ShopPrint_Aplicativo.Listas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Internals.GIFBitmap;

namespace ShopPrint_Aplicativo.Xamls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(String Title, String Url, String Description, String Price)
        {
            InitializeComponent();
            ImagemDetail.Source = Url;
            TituloDetail.Text = Title;
            DescricaoDetail.Text = Description;
            PrecoDetail.Text = Price;
        }

        public void AddCart(object sender, EventArgs e)
        {
            string caminhoDaImagem = (ImagemDetail.Source as FileImageSource)?.File;
            int preco = int.Parse(PrecoDetail.Text);
            Cart novoCart = new Cart
            {
                Title = TituloDetail.Text,
                Url = caminhoDaImagem,
                Price = preco,
                Quantity = 1
            };

            CartList.CartItemList.Add(novoCart);
        }

        private async void CartClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CartPage());
        }
    }
}