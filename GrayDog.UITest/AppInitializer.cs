using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace GrayDog.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.
                    Android.
                    ApkFile(@"E:\TestProjects\GrayDog\GrayDog\GrayDog.Android\bin\Debug\com.companyname.GrayDog.apk").
                    DeviceSerial("R3E6T16921000463").
                    StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}