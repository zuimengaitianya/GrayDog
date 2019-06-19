using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using GrayDog.CustomRenderers;
using GrayDog.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(MyEntry),typeof(MyEntryRenderer))]
namespace GrayDog.iOS.CustomRenderers
{
    public class MyEntryRenderer:EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
        }
    }
}