using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using nexus.protocols.ble;
using UIKit;

namespace GrayDog.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            var color = UIColor.FromRGB(128, 188, 0);
            UITabBar.Appearance.SelectedImageTintColor = color; //settings tab selected color
            UINavigationBar.Appearance.BarTintColor = color; //background of navbar
            UISwitch.Appearance.TintColor = color;
            UISwitch.Appearance.OnTintColor = color;
            UINavigationBar.Appearance.TintColor = UIColor.White; //menu icon color
                                                                  //UINavigationBar.Appearance.BackgroundColor = UIColor.Purple;

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes() { TextColor = UIColor.White }); //TODO: this should be done in xamarin forms
            //https://forums.xamarin.com/discussion/19277/how-to-change-xamarin-form-navigationpage-title-color


            Rg.Plugins.Popup.Popup.Init();

            IBluetoothLowEnergyAdapter bleAdapter = null;
            
            bleAdapter = BluetoothLowEnergyAdapter.ObtainDefaultAdapter();

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(bleAdapter));

            return base.FinishedLaunching(app, options);
        }
    }
}
