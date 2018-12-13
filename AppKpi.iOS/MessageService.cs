using System;
using AppKpi.dependencyservice;
using UIKit;

namespace AppKpi.iOS
{
    public class MessageService : IMessageService, IUIAlertViewDelegate
    {
        public IntPtr Handle { get; set; }

        public void Dispose()
        {
        }

        public void LongAlert(string message)
        {
            UIAlertView alert = new UIAlertView("Alerta", message, this, "OK");
            alert.Show();
        }

        public void ShortAlert(string message)
        {
            UIAlertView alert = new UIAlertView("Alerta", message, this, "OK");
            alert.Show();
        }

    }
}