using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrayDog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NavePage : ContentPage
	{
		public NavePage ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScrollImagePage());
        }
    }
}