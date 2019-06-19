using System;
using System.Collections.Generic;
using System.Text;

namespace GrayDog.DependencyServices
{
    public interface ICustomAlertDialog
    {
        void Dismiss();
        void ShowCustomDialog(Action ConfirmAction, Action CancelAction, string title, string confirm, string cancel, string content);
    }
}
