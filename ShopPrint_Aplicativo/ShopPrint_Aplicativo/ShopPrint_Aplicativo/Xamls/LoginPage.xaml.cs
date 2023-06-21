using Newtonsoft.Json;
using ShopPrint_Aplicativo.Classes;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string url = "https://172.19.176.1:7150/User/Login";

            // Criar HttpClientHandler com callback de validação de certificado personalizado
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (s, cert, chain, sslPolicyErrors) => true;

            // Passar o handler para HttpClient
            HttpClient client = new HttpClient(clientHandler);

            // Criar o conteúdo da solicitação (JSON)
            var json = new
            {
                email = txtUsername.Text,
                password = txtPassword.Text
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(json),
                Encoding.UTF8,
                "application/json"
            );

            try
            {
                // Enviar solicitação POST para a API
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    // Obter o ID do usuário e o token da resposta da API
                    var responseData = await response.Content.ReadAsStringAsync();
                    var loginData = JsonConvert.DeserializeObject<LoginResponse>(responseData);

                    // Salvar o ID do usuário e o token nas preferências do aplicativo
                    Preferences.Set("UserId", loginData.UserId);
                    Preferences.Set("Token", loginData.Token);

                    // Salvar o ID do usuário nas preferências do aplicativo
                    // Login bem-sucedido, navegar para a página inicial
                    await Navigation.PushAsync(new HomePage());
                }
                else
                {
                    // Exibir mensagem de erro de login
                    await DisplayAlert("Tente Novamente", "Login ou senha estão incorretos", "OK");
                }
            }
            catch (Exception ex)
            {
                // Lidar com erros de conexão ou outras exceções
                await DisplayAlert("Erro", "Ocorreu um erro ao tentar fazer login: " + ex.Message, "OK");
            }
        }


        private void Send_Register(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
