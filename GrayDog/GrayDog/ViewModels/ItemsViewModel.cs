using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using GrayDog.Models;
using GrayDog.Views;
using GrayDog.DependencyServices;

namespace GrayDog.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        
        public Command StartTimeComm { get; set; }
        public Command EndTimeComm { get; set; }

        public Command SwipeCommand { get; set; }

        public HtmlWebViewSource html { get; set; }

        System.Timers.Timer timer = null;
        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            StartTimeComm = new Command(StartTimeClick);
            EndTimeComm = new Command(EndTimeClick);
            //SwipeCommand = new Command(OnSwiped);
            timer = new System.Timers.Timer(200);
            timer.Elapsed += Timer_Elapsed;

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });

            html = new HtmlWebViewSource();
            html.BaseUrl = DependencyService.Get<IBaseUrl>().Get();
            html.Html = DependencyService.Get<IBaseUrl>().GetHtml("ImageTest.html");
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
        }
        async void OnSwiped(object sender, SwipedEventArgs e)
        {
            Image image = sender as Image;
            await image.TranslateTo(200, 0, 1000);
        }
        async void StartTimeClick()
        {
            
            //timer.Start();
        }
        async void EndTimeClick()
        {
            await Task.Run(() => { timer.Stop(); }); 
            //timer.Close();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}