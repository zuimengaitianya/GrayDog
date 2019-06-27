using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrayDog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HybridWebViewPage : ContentPage
	{
		public HybridWebViewPage ()
		{
			InitializeComponent ();
            hybridWebView.HttpScource = "http://10.0.18.35/v1/Home/ShowToolsImgList?modelNumber=123&language=zh&brand=Developer";
            hybridWebView.RegisterAction((data) => DisplayAlert("Alert", data, "OK"));
		}
	}
}