using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using ShopPrint_Aplicativo.Xamls;
using Xamarin.Forms;

namespace ShopPrint_Aplicativo
{
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();
            LoadProducts();
        }

        private async void LoadProducts()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://179.172.246.251:7150/");

                    HttpResponseMessage response = await client.GetAsync("Product/GetAll");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        List<Products> products = JsonConvert.DeserializeObject<List<Products>>(content);

                        ItemList.ItemsSource = products;
                    }
                    else
                    {
                        await DisplayAlert("Error", "Failed to retrieve products.", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "An error occurred while loading products: " + ex.Message, "OK");
            }
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Products;
            await Navigation.PushAsync(new DetailPage(details.Id));
        }

        private async void CartClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CartPage());
        }
    }
}
