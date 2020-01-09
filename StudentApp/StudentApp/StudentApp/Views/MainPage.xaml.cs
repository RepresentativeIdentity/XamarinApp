using StudentApp.Models;
using StudentApp.Services;
using StudentApp.ViewModels;
using StudentApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace StudentApp
{
    public partial class MainPage : ContentPage
    {

        private MainViewModel imSoruce = new MainViewModel();
        public MainPage(object studentInfo)
        {
    
            InitializeComponent();

            ShowImage();
            BindingContext = studentInfo;
           
          
        }

        private void Profit(object sender, EventArgs e)
        {

            var isConnected = InternetConnection.InternetCheck();
            if (isConnected)
            {
               Navigation.PushAsync(new ProfitPage() { BackgroundColor = Color.FromHex("#127ac7") });
            }
            if(!isConnected)
            {
                App.Current.MainPage.DisplayAlert("Greška", "Provjerite vašu internet vezu.\nPotrebno je koristiti Wi-Fi ili mobilni internet.", "Uredu");
            }
        }

   

        private void Contracts(object sender, EventArgs e)
        {
            var isConnected = InternetConnection.InternetCheck();
            if (isConnected)
            {
                Navigation.PushAsync(new ContractPage() { BackgroundColor = Color.FromHex("#127ac7") });
            }
            if(!isConnected)
            {
                App.Current.MainPage.DisplayAlert("Greška", "Provjerite vašu internet vezu.\nPotrebno je koristiti Wi-Fi ili mobilni internet.", "Uredu");
            }

        }



        public void ShowImage()
        {

            string source = imSoruce.GetImage();
            if (string.IsNullOrEmpty(source))
            {
                MyImage.Source = FileImageSource.FromFile("miss.png");
                return;
            }
            var byteArray = Convert.FromBase64String(source);

            Stream stream = new MemoryStream(byteArray);
            var imageSource = Xamarin.Forms.ImageSource.FromStream(() => stream);
            MyImage.Source = imageSource;

        }


        protected override bool OnBackButtonPressed()
        {
            return true;
        }


        private void Logout(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage() { BackgroundColor = Color.FromHex("#127ac7") });
 
        }



      




    }
}
