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
using GrayDog.DependencyServices;
using GrayDog.Droid.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidCustomAlertDialog))]
namespace GrayDog.Droid.DependencyServices
{
    public class DroidCustomAlertDialog : ICustomAlertDialog
    {
        public void Dismiss()
        {
            throw new NotImplementedException();
        }

        public void ShowCustomDialog(Action ConfirmAction, Action CancelAction, string title, string confirm, string cancel, string content)
        {
            //Activity activity = (Activity)Forms.Context;
            //AndroidCommon.CustomAlertDialog dialog = new AndroidCommon.CustomAlertDialog(activity.WindowManager, activity).Builder();

            //if (!string.IsNullOrEmpty(title))
            //{
            //    dialog.SetTitle(title);
            //}

            //dialog.SetCancelable(false).SetCanceledOnTouchOutside(false);

            //if (!string.IsNullOrEmpty(cancel))
            //{
            //    dialog.SetNegativeButton(cancel, CancelAction);
            //}

            //if (!string.IsNullOrEmpty(confirm))
            //{
            //    dialog.SetPositiveButton(confirm, ConfirmAction);
            //}

            ////if (isTextLeft)
            ////{
            ////    dialog.SetMsgLeft();
            ////}

            //dialog.SetMsg(content);

            //dialog.Show();
        }
    }
}