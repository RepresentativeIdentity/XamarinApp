using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.RestClient;
using StudentApp.Models;
using StudentApp.Services;
using StudentApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StudentApp.ViewModels
{
    public class MainViewModel : INotifyBaseClass
    {


        private Student _studentObject;

        public Student StudentObject
        {
            get { return _studentObject; }
            set
            {
                _studentObject = value;
                OnPropertyChanged();
            }
        }

        //dodano za prijavu
        private Login _studentLoginInfo;

        public Login StudentLoginInfo 
        {
            get { return _studentLoginInfo; }
            set
            {
                _studentLoginInfo = value;
                OnPropertyChanged();
            }
        }

        
        public MainViewModel()
        {
            InitializeDataAsync();
            StudentLoginInfo = new Login
            {
                jmbg = ""
            };
        }
       

        private async Task InitializeDataAsync()
        {
            RestAccess = new Command(RestAccessAsync);
            Loading = false;
        }



        public Command Help
        {
            get
            {
                return new Command(() =>
                {
                    var isConnected = InternetConnection.InternetCheck();
                    if (isConnected && !Loading)
                    {
                        Device.OpenUri(new Uri("http://www.aaiedu.hr/"));
                    }
                    if (!isConnected)
                    {
                        App.Current.MainPage.DisplayAlert("Greška", "Provjerite vašu internet vezu.\nPotrebno je koristiti Wi-Fi ili mobilni internet.", "Uredu");
                    }
                });
            }
        }


        public static string sToken;

        public string GetToken()
        {
       
            return sToken;
        }

        private static string sImage;
        public string GetImage()
        {
            return sImage;
        }

        //prijava
        public Command RestAccess
        {
            
            get; set;
            
        }

        private async void RestAccessAsync()
        {
            var isConnected = InternetConnection.InternetCheck();
            if (isConnected && !Loading)
            {
                var studentServices = new StudentServices();
                if (StudentLoginInfo.jmbg != "")
                {
                    Loading = true; //activityIndicator
                    StudentLoginInfo = await studentServices.GetStudentLoginAsync(StudentLoginInfo.jmbg);

                    if (StudentLoginInfo.Token != null)
                    {
                        StudentObject = await studentServices.GetStudentObjectAsync(StudentLoginInfo.Token);

                        sToken = StudentLoginInfo.Token; //spremanje tokena 

                        var imageSoruce = await studentServices.GetStudentImageAsync(sToken); //dohvacanje slike
                        sImage = imageSoruce;

                        if (StudentObject != null)
                        {

                            var studentInfo = GetStudentInfo(); //spremanje podataka 
                            await Application.Current.MainPage.Navigation.PushAsync(new MainPage(studentInfo));
                        }


                    }
                    else if (StudentLoginInfo.Token == null)
                    {
                        Loading = false;
                        await App.Current.MainPage.DisplayAlert("Obavijest", "Pogrešan unos, pokušajte ponovo.", "Uredu");
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Obavijest", "Potrebno je ispuniti polje korisnička oznaka za prijavu - JMBAG.", "Uredu");
                    //return;

                }
            }
            if(!isConnected)
                await App.Current.MainPage.DisplayAlert("Greška", "Provjerite vašu internet vezu.\nPotrebno je koristiti Wi-Fi ili mobilni internet.", "Uredu");
              

        }



        public object GetStudentInfo()
        {
            var student = new Student
            {
                Ime = StudentObject.Ime,
                Prezime = StudentObject.Prezime,
                OIB = StudentObject.OIB,
                JMBAG = StudentObject.JMBAG,
                Ulica = StudentObject.Ulica,
                KucniBroj = StudentObject.KucniBroj,
                Telefon = StudentObject.Telefon,
                MatBr = StudentObject.MatBr,
                Mail = StudentObject.Mail,
                MjestoStanovanja = StudentObject.MjestoStanovanja,
                MjestoBoravista = StudentObject.MjestoBoravista,
                IBANRacuna = StudentObject.IBANRacuna,
                ServisClanstvoDoDatum = StudentObject.ServisClanstvoDoDatum

            };
            if (StudentObject.ServisClanstvoDoDatum != null && StudentObject.ServisClanstvoDoDatum != " - ")
            {
                var convert = DateTime.Parse(student.ServisClanstvoDoDatum);
                var day = convert.Day;
                var month = convert.Month;
                var year = convert.Year;

                var result = DateParse(day, month, year);

                student.ServisClanstvoDoDatum = result.ToString();

            };

            return student;
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


     


        public Command TestPage
        {  
            get
            {
                return new Command( () =>
                {
                     Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                });
            }
        }








    }
}
