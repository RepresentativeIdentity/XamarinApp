using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.ViewModels
{
    public class INotifyBaseClass : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        public string DateParse(int day, int month, int year)
        {
            var result = "";

            if (day < 10 && month < 10)
                result = "0" + day + "." + "0" + month + "." + year + ".";
            else if (day < 10)
                result = "0" + day + "." + month + "." + year + ".";
            else if (month < 10)
                result = day + "." + "0" + month + "." + year + ".";
            else
                result = day + "." + month + "." + year + ".";

            return result;
        }




    }
}
