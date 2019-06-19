using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using GrayDog.CustomRenderers;
using GrayDog.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace GrayDog.Droid.CustomRenderers
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(Android.Graphics.Color.Transparent);
                gd.SetCornerRadius(10);
                gd.SetStroke(5, Android.Graphics.Color.LightGray);//边框宽度和边框颜色
                this.Control.SetBackgroundDrawable(gd);
            }
        }
    }
}