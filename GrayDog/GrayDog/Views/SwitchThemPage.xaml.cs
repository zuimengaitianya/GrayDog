using GrayDog.DependencyServices;
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
    public partial class SwitchThemPage : ContentPage
    {
        public SwitchThemPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            DependencyService.Get<ISwitchThem>().SetRedTheme();

            //DependencyService.Get<ISwitchThem>().SwitchDroidThem();
            await Navigation.PushModalAsync(new NavigationPage(new PeopleListPage()));
        }
    }
}