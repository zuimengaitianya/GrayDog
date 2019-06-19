using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using GrayDog.DependencyServices;
using GrayDog.iOS.DependencyServices;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSBaseUrl))]
namespace GrayDog.iOS.DependencyServices
{
    public class IOSBaseUrl : IBaseUrl
    {
        public string Get()
        {
            return NSBundle.MainBundle.BundlePath;
        }

        public string GetHtml(string path)
        {
            string html = string.Empty;
            html = File.ReadAllText(Path.Combine(NSBundle.MainBundle.BundlePath, path));
            //var assetManager = MainActivity.Instance.Assets;
            //using (var streamReader = new StreamReader(assetManager.Open("local.html")))
            //{
            //    html = streamReader.ReadToEnd();
            //}
            return html;
        }

    }
}