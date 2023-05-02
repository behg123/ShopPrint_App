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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (txtPassword.Text == null || txtRepeatPassword.Text == null || txtUsername.Text == null)
            {
                DisplayAlert("Tente Novamente", "Campos vazios", "OK");

            }
            else if (txtPassword.Text != txtRepeatPassword.Text)
            {
                DisplayAlert("Tente Novamente", "Senhas estão diferentes", "OK");
            } 
            else
            {
                Navigation.PopAsync();
            }
        }

    }
}