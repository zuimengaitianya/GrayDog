using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GrayDog.Models;
using GrayDog.Views;
using GrayDog.ViewModels;

namespace GrayDog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        async void AnimationBox(BoxView box, double val, uint time, bool first)
        {
            if (first)
            {
                await box.ScaleTo(1, time);
            }
            bool isComplate = await box.ScaleTo(4, 5000);
            if (!isComplate)
            {
                await box.ScaleTo(1, 1);
            }
            AnimationBox(box, 1, 1, false);
        }
        async void BoxFade(BoxView box, double val, uint time, bool first)
        {
            if (first)
            {
                await box.FadeTo(1, time, Easing.Linear);
            }
            bool isComplate = await box.FadeTo(0.1, 5000, Easing.Linear);

            if (!isComplate)
            {
                await box.FadeTo(1, 1, Easing.Linear);
            }
            BoxFade(box, 1, 1, false);
        }
        async void InitBox(BoxView box, double val)
        {
            await box.ScaleTo(val, 4);
        }
        async void InitBoxFade(BoxView box, double val)
        {
            await box.FadeTo(val, 4, Easing.Linear);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //InitBox(box1, 1);
            //InitBoxFade(box1, 1);
            //InitBox(box2, 1.25);
            //InitBoxFade(box2, 0.75);
            //InitBox(box3, 1.5);
            //InitBoxFade(box3, 0.5);
            //InitBox(box4, 1.75);
            //InitBoxFade(box4, 0.25);
            //InitBox(box5, 2.0);
            //InitBoxFade(box5, 0.1);

            AnimationBox(box1, 1, 5000, true);
            BoxFade(box1, 1.0, 5000, true);
            AnimationBox(box2, 1.8, 4000, true);
            BoxFade(box2, 0.8, 4000, true);
            AnimationBox(box3, 2.6, 3000, true);
            BoxFade(box3, 0.6, 3000, true);
            AnimationBox(box4, 3.2, 2000, true);
            BoxFade(box4, 0.4, 2000, true);
            AnimationBox(box5, 4.0, 1000, true);
            BoxFade(box5, 0.2, 1000, true);


            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send<object>(this, "Hi");
            //App app = Xamarin.Forms.Application.Current as App;
            //var masterPage = app.MainPage as Xamarin.Forms.TabbedPage;
            //if(masterPage.CurrentPage.ClassId=="")
            //await Navigation.PushAsync(new AboutPage());
            await Navigation.PushModalAsync(new NavigationPage(new SwipePage()) { });

            //NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}