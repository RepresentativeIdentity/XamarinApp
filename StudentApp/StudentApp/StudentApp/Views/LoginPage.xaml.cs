using Newtonsoft.Json;
using Plugin.Connectivity;
using StudentApp.Services;
using StudentApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
   // [assembly: Xamarin.Forms.Dependency(typeof(AppExit))]
    public partial class LoginPage : ContentPage
	{
        public LoginPage ()
		{
			InitializeComponent ();

        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var choice = await Application.Current.MainPage.DisplayAlert("Obavijest", "Želite li izaći iz aplikacije?", "Ne", "Da");

            if (!choice)
            {
                if (Device.OS == TargetPlatform.Android)
                    DependencyService.Get<IAppExit>().ExitApp();
               
            }



        }
    }
}