using Xamarin.Forms;
using Android.Media;
using System.Threading;
using App_AglCA.Services;
using App_AglCA.Droid;
using Android.Widget;

[assembly: Dependency(typeof(ToastService))]

namespace App_AglCA.Droid
{
    public class ToastService : IToast
    {
        public void Show(string message)  
        {  
            Android.Widget.Toast.MakeText(Android.App.Application.Context,message,ToastLength.Short).Show();  
        } 
    }
}