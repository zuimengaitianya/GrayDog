﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GrayDog.Views;
using System.IO;
using nexus.protocols.ble;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GrayDog
{
    public partial class App : Application
    {
        public static double ScreenWidth;
        public static double ScreenHeight;

        static Database database;
        public static IBluetoothLowEnergyAdapter Adapter { get; set; }

        public App(IBluetoothLowEnergyAdapter iAdapter)
        {
            InitializeComponent();

            Adapter = iAdapter;
            //MainPage = new MainPage();
            //MainPage = new MainButtonPage();
            //MainPage = new TakePhotePage();
            //MainPage = new PeopleListPage();
            //MainPage = new CardsViewPage();
            //MainPage = new HorizontalListViewPage();
            //MainPage = new HybridWebViewPage();
            //MainPage = new BlePage();
            //NavigationPage navigationPage = new NavigationPage(new PeopleListPage())
            //{
            //    //HasNavigationBar
            //    Title = "Tools",
            //    BarTextColor = Color.Black,
            //    BackgroundColor = Color.White,
            //    BarBackgroundColor = Color.Red
            //};

            //MainPage = navigationPage;
            //NavigationPage navigationPage = new NavigationPage(new SwitchThemPage())
            //{
            //    BackgroundColor = Color.Blue,
            //    BarBackgroundColor=Color.Black,
            //};
            //MainPage = navigationPage;
            //MainPage = new SwitchThemPage();
            //MainPage = new SetTabbedPage();
            MainPage = new GuideCarouselPage();
        }

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GrayDog.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
