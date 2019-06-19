using Plugin.Media;
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
	public partial class TakePhotePage : ContentPage
	{
		public TakePhotePage ()
		{
			InitializeComponent ();
            string wrapNewLine= Environment.NewLine;
            lbl.Text = $"可以作为\r\n标识符{wrapNewLine}(类名、变量名、方法名等)的第一个字符，以允许C# 中保留关键字作为自己定义的标识符。如";

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize= Plugin.Media.Abstractions.PhotoSize.Medium,
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            PhoteImg.Source= ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
    }
}