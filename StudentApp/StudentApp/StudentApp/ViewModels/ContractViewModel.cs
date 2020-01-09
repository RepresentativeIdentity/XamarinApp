using StudentApp.Models;
using StudentApp.Services;
using StudentApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StudentApp.ViewModels
{
    public class ContractViewModel : INotifyBaseClass
    {
        
        private List<Contracts> _studentContract;

        public List<Contracts> StudentContract
        {
            get { return _studentContract; }
            set
            {
                _studentContract = value;
                OnPropertyChanged();
            }
        }

        //preuzimanje tokena 
        private MainViewModel token = new MainViewModel();
        private string _token;

     
        public ContractViewModel()
        {
            _token = token.GetToken();
            InitializeDataAsync();

        }

        private async Task InitializeDataAsync()
        {
            Loading = true;
            var studentServices = new StudentServices();
            StudentContract = await studentServices.GetStudentContractAsync(_token);

            Loading = false;
            if(StudentContract.Count == 0)
                await App.Current.MainPage.DisplayAlert("Obavijest", "Trenutno ne postoje podaci o ugovorima.", "Uredu");
        }


   


        public Command Refresh
        {
            get
            {
                return new Command(async () =>
                {
                    var studentServices = new StudentServices();
                    StudentContract = await studentServices.GetStudentContractAsync(_token);

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





        private string _keyword;

        public string Keyword
        {
            get { return _keyword; }
            set
            {
                _keyword = value;
                OnPropertyChanged();

            }
        }


        public Command SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var studentServices = new StudentServices();
                    StudentContract = await studentServices.GetStudentContractSearchAsync(_token, _keyword);

                });
            }
        }





        //prosirenje za dohvacanje dodatnih informacija o ugovorima


        private Contracts _studentContractItem;

        public Contracts StudentContractItem
        {
            get { return _studentContractItem; }
            set
            {
                _studentContractItem = value;
                OnPropertyChanged();
            }
        }



        public Command ListContractDetails
        {
            get
            {
                return new Command( async () =>
                {
                    var contract = GetContractItem();
                    if (contract != null)
                        await Application.Current.MainPage.Navigation.PushAsync(new ContractDetailsPage(contract));
                    else
                        await App.Current.MainPage.DisplayAlert("Greška", "Dohvaćanje dodatnih informacija nije uspješno pokušajte ponovo.", "U redu");
                });
            }
        }



        public object GetContractItem()
        {
            var contract = new Contracts
            {
               
                BpCodeTvrtka = StudentContractItem.BpCodeTvrtka,
                BpNameTvrtka = StudentContractItem.BpNameTvrtka,
                DatumIzdavanja = StudentContractItem.DatumIzdavanja,
                IsplacenoStudentu = StudentContractItem.IsplacenoStudentu,
                IznosNeto = StudentContractItem.IznosNeto,
                UgovorBroj = StudentContractItem.UgovorBroj,
                RacunDatum = StudentContractItem.RacunDatum,
                DatumZatvaranjaRacuna = StudentContractItem.DatumZatvaranjaRacuna,
                Porez = StudentContractItem.Porez,
                Prirez = StudentContractItem.Prirez

            };


            if (StudentContractItem.DatumZatvaranjaRacuna != null && StudentContractItem.DatumZatvaranjaRacuna != " - ")
            {
                var convert = DateTime.Parse(contract.DatumZatvaranjaRacuna);
                var day = convert.Day;
                var month = convert.Month;
                var year = convert.Year;

                var result = DateParse(day, month, year);

                contract.DatumZatvaranjaRacuna = result.ToString();

            };

            if (StudentContractItem.RacunDatum != null && StudentContractItem.RacunDatum != " - ")
            {
                var convert = DateTime.Parse(contract.RacunDatum);
                var day = convert.Day;
                var month = convert.Month;
                var year = convert.Year;

                var result = DateParse(day, month, year);

                contract.RacunDatum = result.ToString();

            };

            return contract;
        }

        //kraj prosirenja





        }
}
