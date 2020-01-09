using Plugin.Connectivity;
using StudentApp.ViewModels;
using StudentApp.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;

using Xamarin.Forms;

namespace StudentApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppCenter.Start("c42828b2-9b01-40e8-a9d5-664ec9286f42", typeof(Push));

            MainPage = new NavigationPage(new LoginPage()) { BarBackgroundColor = Color.FromHex("#b3b3b3") };
            // MainPage = new NavigationPage(new TestPage()) { BarBackgroundColor = Color.FromHex("#127ac7") };


            //definiranje nove valute {0:C2} - HRK
            CultureInfo croCurrency = new CultureInfo("hr-HR");
            CultureInfo.DefaultThreadCurrentCulture = croCurrency;
            


        }

        protected override void OnStart()
        {
            
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
           
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        


    }
}
