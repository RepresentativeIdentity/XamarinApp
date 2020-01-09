using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudentApp.Views;
using Xamarin.Forms;

namespace Plugin.RestClient
{
    /// <summary>
    /// RestClient implements methods for calling CRUD operations
    /// using HTTP.
    /// </summary>
    public class RestClient<T>
    {

        private const string WebServiceUrl = "";

        //Test student
        private const string WebServiceUrlProfit = "http://";
        private const string WebServiceUrlData = "http://";
        private const string WebServiceUrlContract = "http://";
        private const string WebServiceUrlImage = "http://";


        public async Task<T> GetObjectAsync(string token)
        {
           
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await httpClient.GetAsync(WebServiceUrlData);
                if (json.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await json.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<T>(result);
                    return response;
                }
                return default(T);

            }
            catch
            {
                return default(T);
            }


        }


        //za prijavu
        public async Task<T> GetLoginAsync(string jmbag)
        {
            
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetAsync("http://" + jmbag + "//");
                if (json.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await json.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<T>(result);
                    return response;
                }

                return default(T);
              
               
            }
            catch 
            {
                return default(T);
            }
        }

        //zarade po godinama
         public async Task<List<T>> GetProfitAsync(string token)
        {
            var httpClient = new HttpClient();

            
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var json = await httpClient.GetStringAsync(WebServiceUrlProfit);

            var response = JsonConvert.DeserializeObject<List<T>>(json);

            return response;
        }


        //ugovori
        public async Task<List<T>> GetContractAsync(string token)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var json = await httpClient.GetStringAsync(WebServiceUrlContract);

            var response = JsonConvert.DeserializeObject<List<T>>(json);

            return response;
        }


        //slika
        public async Task<T> GetImageAsync(string token)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var json = await httpClient.GetStringAsync(WebServiceUrlImage);

                var response = JsonConvert.DeserializeObject<T>(json);

                return response;
            }
            catch
            {
                return default(T);
            }
        }




        //#ugovor
        public async Task<T> GetContractItemAsync(string token, object item)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var json = await httpClient.GetStringAsync(WebServiceUrlContract);

            var response = JsonConvert.DeserializeObject<T>(json);

            return response;
        }





        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();
          
            var json = await httpClient.GetStringAsync(WebServiceUrlProfit);

            var response = JsonConvert.DeserializeObject<List<T>>(json.ToString());

            return response;
        }

        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(WebServiceUrl + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);

            return response.IsSuccessStatusCode;
        }



    }
}
