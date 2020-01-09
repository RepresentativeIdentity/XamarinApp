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
using StudentApp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AppQuit))]
namespace StudentApp.Droid
{
    public class AppQuit : IAppExit
    {
        public void ExitApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}