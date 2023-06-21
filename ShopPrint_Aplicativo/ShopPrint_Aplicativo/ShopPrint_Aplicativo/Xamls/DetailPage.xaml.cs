using Newtonsoft.Json;
using ShopPrint_Aplicativo.Classes;
using ShopPrint_Aplicativo.Listas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Internals.GIFBitmap;

namespace ShopPrint_Aplicativo.Xamls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        private int productId;
        public DetailPage(int Id)
        {
            InitializeComponent();
            productId = Id;
            LoadProductDetails(Id);
        }

        private async void LoadProductDetails(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7150/");

                    HttpResponseMessage response = await client.GetAsync($"Product/GetById/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Products product = JsonConvert.DeserializeObject<Products>(content);

                        // Update the UI with the product details
                        ImagemDetail.Source = product.Image;
                        TituloDetail.Text = product.Name;
                        DescricaoDetail.Text = product.Description;
                        PrecoDetail.Text = product.Price.ToString();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Failed to retrieve product details.", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "An error occurred while loading product details: " + ex.Message, "OK");
            }
        }

        public async void AddCart(object sender, EventArgs e)
        {
            string userId = Preferences.Get("UserId", string.Empty);
            string token = Preferences.Get("Token", string.Empty);

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    string url = "https://localhost:7150/Cart/AddItem";

                    var json = new
                    {
                        userId = userId,
                        productId = productId
                    };

                    var content = new StringContent(
                        JsonConvert.SerializeObject(json),
                        Encoding.UTF8,
                        "application/json"
                    );

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Sucesso", "Produto adicionado ao carrinho com sucesso", "OK");
                    }
                    else
                    {
                        // Exibir mensagem de erro
                        await DisplayAlert("Erro", "Produto indisponível", "OK");
                    }
                }
                catch (Exception ex)
                {
                    // Lidar com erros de conexão ou outras exceções
                    await DisplayAlert("Erro", "Ocorreu um erro ao adicionar o produto ao carrinho: " + ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Aviso", "Você precisa estar logado para adicionar um item ao carrinho", "OK");
            }
        }


        private async void CartClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CartPage());
        }
    }
}