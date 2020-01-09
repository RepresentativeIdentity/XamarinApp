using StudentApp.Models;
using StudentApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContractPage : ContentPage
    {
        public ContractPage()
        {  

            InitializeComponent();
            
        }


        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var vm = BindingContext as ContractViewModel;
            vm.SearchCommand.Execute(null);
        }

        public void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var contractDetails = list.SelectedItem;

            var vm = BindingContext as ContractViewModel;
            vm.StudentContractItem = contractDetails as Contracts;

            if(contractDetails != null)
                vm.ListContractDetails.Execute(null);

        }

        //odznacavanje liste
        protected override void OnAppearing()
        {
            list.SelectedItem = null;
        }

        

    }
}