using Newtonsoft.Json;
using ShopPrint_Aplicativo.Classes;
using ShopPrint_Aplicativo.Listas;
using ShopPrint_Aplicativo.Xamls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopPrint_Aplicativo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        private HttpClient client;
        public CartPage()
        {
            InitializeComponent();
            client = new HttpClient();
            LoadCartItems();
        }

        private async void LoadCartItems()
        {
            try
            {
                string userId = Preferences.Get("UserId", string.Empty);
                string token = Preferences.Get("Token", string.Empty);

                if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(userId))
                {
                    string url = "https://localhost:7150/Cart/GetByUserId/" + userId;

                    var request = new HttpRequestMessage(HttpMethod.Get, url);
                    request.Headers.Add("Authorization", "Bearer " + token);

                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        string cartItemsData = await response.Content.ReadAsStringAsync();
                        Cart cart = JsonConvert.DeserializeObject<Cart>(cartItemsData);

                        cartListView.ItemsSource = cart.Items;

                        int totalPrice = 0;
                        foreach (var item in cart.Items)
                        {
                            totalPrice += item.Price;
                        }
                        Preco.Text = totalPrice.ToString();
                    }
                    else
                    {
                        // Handle empty cart
                        ShowEmptyCartMessage();
                    }
                }
                else
                {
                    await DisplayAlert("Error", "User not authenticated", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Failed to load cart items: " + ex.Message, "OK");
            }
        }

        private void ShowEmptyCartMessage()
        {
            cartListView.IsVisible = false;

        }


        private async void AddQuantity(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Cart)button.BindingContext;

            string userId = Preferences.Get("UserId", string.Empty);
            var productId = item.id; 

            var data = new
            {
                userId,
                productId
            };

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PutAsync("https://localhost:7150/Cart/AddItem/", content);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Sucesso", "Item adicionado ao carrinho", "OK");
                }
                else
                {
                    await DisplayAlert("Erro", "Ocorreu um erro ao adicionar o item ao carrinho", "OK");
                }
            }
        }


        private async void RemoveQuantity(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Cart)button.BindingContext;

            string userId = Preferences.Get("UserId", string.Empty);
            var productId = item.id;

            var data = new
            {
                userId,
                productId
            };

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PutAsync("https://localhost:7150/Cart/RemoveItem/", content);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Sucesso", "Item removido do carrinho", "OK");
                }
                else
                {
                    await DisplayAlert("Erro", "Ocorreu um erro ao adicionar o item ao carrinho", "OK");
                }
            }
        }

        private async void DeleteQuantity(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var item = (Cart)button.BindingContext;

            string userId = Preferences.Get("UserId", string.Empty);
            var productId = item.id; 

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://localhost:7150/Cart/RemoveProduct"),
                Content = new StringContent($"{{ \"userId\": \"{userId}\", \"productId\": \"{productId}\" }}", Encoding.UTF8, "application/json")
            };

            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Sucesso", "Item removido do carrinho", "OK");
                }
                else
                {
                    await DisplayAlert("Erro", "Ocorreu um erro ao remover o item do carrinho", "OK");
                }
            }
        }


        private async void Checkout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckoutPage());
        }
    }
}