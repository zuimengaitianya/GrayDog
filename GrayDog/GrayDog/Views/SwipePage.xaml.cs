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
    public partial class SwipePage : ContentPage
    {
        public SwipePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    // Handle the swipe
                    swipeImg.TranslateTo(-100, 0, 1000);
                    break;
                case SwipeDirection.Right:
                    swipeImg.TranslateTo(100, 0, 1000);
                    // Handle the swipe
                    break;
                case SwipeDirection.Up:
                    // Handle the swipe
                    break;
                case SwipeDirection.Down:
                    // Handle the swipe
                    break;
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Title", "Message", "Cancel");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavePage());
            //await Navigation.PushAsync(
            //    new NavigationPage(new NavePage())
            //    {
            //        BackgroundColor = Color.FromHex("3bb77"),
            //        BarTextColor = Color.White
            //    });
        }
    }
}