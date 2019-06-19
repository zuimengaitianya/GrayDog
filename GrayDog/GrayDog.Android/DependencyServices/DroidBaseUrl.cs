using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GrayDog.DependencyServices;
using GrayDog.Droid.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidBaseUrl))]
namespace GrayDog.Droid.DependencyServices
{
    public class DroidBaseUrl : IBaseUrl
    {
        public string Get()
        {
            return "file:///android_asset/";
        }

        public string GetHtml(string path)
        {
            string html = string.Empty;
            var assetManager = MainActivity.Instance.Assets;
            using (var streamReader = new StreamReader(assetManager.Open(path)))
            {
                html = streamReader.ReadToEnd();
            }
            return html;
        }
    }

}