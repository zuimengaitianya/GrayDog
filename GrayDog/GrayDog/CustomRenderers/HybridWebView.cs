﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GrayDog.CustomRenderers
{
    public class HybridWebView : View
    {
        Action<string> action;
        public static readonly BindableProperty UriProperty = BindableProperty.Create(
          propertyName: "Uri",
          returnType: typeof(string),
          declaringType: typeof(HybridWebView),
          defaultValue: default(string));

        public static readonly BindableProperty HttpSourceProperty = BindableProperty.Create(
            propertyName: "HttpScource",
            returnType: typeof(string),
            declaringType: typeof(HybridWebView),
            defaultValue: default(string));

        public string HttpScource
        {
            get { return (string)GetValue(HttpSourceProperty); }
            set { SetValue(HttpSourceProperty, value); }
        }

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }

        public void RegisterAction(Action<string> callback)
        {
            action = callback;
        }

        public void Cleanup()
        {
            action = null;
        }

        public void InvokeAction(string data)
        {
            if (action == null || data == null)
            {
                return;
            }
            action.Invoke(data);
        }
    }
}
