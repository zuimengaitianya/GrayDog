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
            NavigationPage navigationPage = (NavigationPage)Application.Current.MainPage;
            navigationPage.BarBackgroundColor = Color.Red;
            
            await Navigation.PushAsync(new PeopleListPage());
            //DependencyService.Get<ISwitchThem>().SwitchDroidThem();
            //await Navigation.PushModalAsync(new NavigationPage(new PeopleListPage())
            //{
            //    BackgroundColor = Color.Blue
            //});

            Button button = new Button() {
                //Image=
            };
            ImageButton imageButton = new ImageButton();
        }
    }
}