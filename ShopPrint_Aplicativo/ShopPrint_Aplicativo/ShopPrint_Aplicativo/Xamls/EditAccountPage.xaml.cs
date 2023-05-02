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
	public partial class EditAccountPage : ContentPage
	{
		public EditAccountPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());

        }
    }


}