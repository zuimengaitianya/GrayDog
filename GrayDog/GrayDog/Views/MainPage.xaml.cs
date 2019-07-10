using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrayDog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<object>(this, "Hi", (obj) =>
            {
                CurrentPage = Children[1];
            });
            //this.SelectedTabColor
            //TabbedPage
        }
    }
}