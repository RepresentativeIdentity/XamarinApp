using StudentApp.Models;
using StudentApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StudentApp.ViewModels
{
    public class ProfitViewModel : INotifyBaseClass
    {
        

        private List<Profit> _studentProfit;

        public List<Profit> StudentProfit
        {
            get { return _studentProfit; }
            set
            {
                _studentProfit = value;
                OnPropertyChanged();
            }
        }

        //preuzimanje tokena 
        private MainViewModel token = new MainViewModel();
        private string _token;

        public ProfitViewModel()
        {
            _token = token.GetToken();
            InitializeDataAsync();
           
        }
        
        private async Task InitializeDataAsync()
        {
           Loading = true;
           var studentServices = new StudentServices();
           StudentProfit = await studentServices.GetStudentProfitAsync(_token);
            Loading = false;
            if (StudentProfit.Count == 0)
               await App.Current.MainPage.DisplayAlert("Obavijest", "Trenutno ne postoje podaci o zaradi.", "U redu");
           
           
        }





        public Command Refresh
        {
            get
            {
                return new Command(async () =>
                {
                    var studentServices = new StudentServices();
                    StudentProfit = await studentServices.GetStudentProfitAsync(_token);

                });
            }

        }



        //ucitavanje
        private bool _loading;

        public bool Loading
        {
            get { return _loading; }

            set
            {
                _loading = value;
                OnPropertyChanged();
            }
        }





    }
}
