using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ShopPrint_Aplicativo
{
    public partial class EditAccountPage : ContentPage
    {
        public EditAccountPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Create the JSON payload
            var json = new
            {
                id = "string",
                userName = txtUsername.Text,
                email = txtEmail.Text,
                password = txtPassword.Text,
                phoneNumber = txtTelefone.Text,
                role = "string"
            };

            // Serialize the JSON payload
            var content = new StringContent(
                JsonConvert.SerializeObject(json),
                Encoding.UTF8,
                "application/json"
            );

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Set the base URL of the API
                    client.BaseAddress = new Uri("https://localhost:7150/");

                    // Send the POST request to the specific endpoint
                    HttpResponseMessage response = await client.PostAsync("User/Update", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // User information updated successfully
                        await DisplayAlert("Success", "User information updated.", "OK");
                    }
                    else
                    {
                        // Handle unsuccessful response
                        await DisplayAlert("Error", "Failed to update user information.", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle connection or other exceptions
                await DisplayAlert("Error", "An error occurred while updating user information: " + ex.Message, "OK");
            }
        }
    }
}
