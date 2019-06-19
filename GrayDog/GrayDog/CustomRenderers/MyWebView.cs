using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GrayDog.CustomRenderers
{
    public class MyWebView : WebView
    {
        public event EventHandler<EventArgs> CallAction;
        public void SendClick(string data)
        {
            CallAction?.Invoke(this, new EventArgs());
        }
    }
}
