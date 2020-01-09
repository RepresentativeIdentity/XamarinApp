using Plugin.RestClient;
using StudentApp.Models;
using StudentApp.ViewModels;
using StudentApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace StudentApp.Services
{
    public class StudentServices : ValidationChecker
    {


        //podaci o studentu
        public async Task<Student> GetStudentObjectAsync(string token)
        {
             RestClient<Student> restClient = new RestClient<Student>();

             var studentObject = await restClient.GetObjectAsync(token);

            StudentValidation(studentObject);

            if (studentObject != null)
             return studentObject;
            return new Student();
        }


        //prijava
        public async Task<Login> GetStudentLoginAsync(string jmbag)
        {
            RestClient<Login> restClient = new RestClient<Login>();  

            var studentObject = await restClient.GetLoginAsync(jmbag);

            if(studentObject != null)
                return studentObject;
            return new Login(); 
        }

        //zarada
        public async Task<List<Profit>> GetStudentProfitAsync(string token)
        {
            RestClient<Profit> restClient = new RestClient<Profit>();

            var studentObject = await restClient.GetProfitAsync(token);

            return studentObject;
        }


        //ugovori
        public async Task<List<Contracts>> GetStudentContractAsync(string token)
        {
            RestClient<Contracts> restClient = new RestClient<Contracts>();

            var studentObject = await restClient.GetContractAsync(token);

            ContractsValidation(studentObject);

            return studentObject;
        }


        //slika
        public async Task<string> GetStudentImageAsync(string token)
        {
            RestClient<string> restClient = new RestClient<string>();

            var studentObject = await restClient.GetImageAsync(token);
          

            return studentObject;
        }



        //pretrazivanje
        public async Task<List<Contracts>> GetStudentContractSearchAsync(string token, string keyword)
        {
            RestClient<Contracts> restClient = new RestClient<Contracts>();

            var studentObject = await restClient.GetContractAsync(token);

            ContractsValidation(studentObject);

            var contractNames = studentObject.Where(x => x.BpNameTvrtka.ToLower().StartsWith(keyword.ToLower()));

            return contractNames.ToList();
        }






    }
}
