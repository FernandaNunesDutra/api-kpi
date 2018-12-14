using Android.App;
using Android.Widget;
using AppKpi.dependencyservice;
using AppKpi.Droid.dependencyservice;

[assembly: Xamarin.Forms.Dependency(typeof(MessageService))]
namespace AppKpi.Droid.dependencyservice
{
    public class MessageService : IMessageService
    {

        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }

    }
}