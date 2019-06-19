using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GrayDog.CustomContainer
{
    public class PanContainer : ContentView
    {
        double x, y;
        public PanContainer()
        {
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += PanGesture_PanUpdated;
            GestureRecognizers.Add(panGesture);
        }

        private void PanGesture_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                    Content.TranslationX =
                      Math.Max(Math.Min(0, x + e.TotalX), -Math.Abs(Content.Width - App.ScreenWidth));
                    Content.TranslationY =
                      Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs(Content.Height - App.ScreenHeight));
                    break;

                case GestureStatus.Completed:
                    // Store the translation applied during the pan
                    x = Content.TranslationX;
                    y = Content.TranslationY;
                    break;
            }
        }
    }
}
