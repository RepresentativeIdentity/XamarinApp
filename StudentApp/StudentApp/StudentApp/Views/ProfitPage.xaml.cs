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
	public partial class ProfitPage : ContentPage
	{
		public ProfitPage ()
		{
			InitializeComponent ();
            BackgroundColor = Color.FromHex("#127ac7");

        }


        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}