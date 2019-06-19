using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.CurrentActivity;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace GrayDog.Droid
{
    [Activity(Label = "GrayDog", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Instance = this;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //初始化UITest
            AppCenter.Start("6be9c596-5920-47cc-bac1-cd2a5b3709b5",
                   typeof(Analytics), typeof(Crashes));

            //初始化弹窗
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

            //初始化takephoto
            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            //base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}