using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Services
{
    public class InternetConnection
    {

        //dodan plugin xam.plugin.connectivity i wifi info
        public static bool InternetCheck()
        {
            bool isConnected = false;

            try
            {
                isConnected = CrossConnectivity.Current.IsConnected;
                return isConnected;
            }
            catch
            {
                return isConnected;
            }
           
       
        }

    }
}
