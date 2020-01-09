using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace StudentApp.ViewModels
{
    public class ValidationChecker
    {

        public void StudentValidation(object stud)
        {
            var student = stud as Student;

            if (student.Ime == null)
                student.Ime = " - ";

            if (student.Prezime == null)
                student.Prezime = " - ";

            if (student.OIB == null)
                student.OIB = " - ";

            if (student.JMBAG == null)
                student.JMBAG = " - ";
            
            if (student.KucniBroj == null)
                student.KucniBroj = " - ";

            if (student.Telefon == null)
                student.Telefon = " - ";

            if (student.Ulica == null)
                student.Ulica = " - ";

            if (student.MjestoBoravista == null)
                student.MjestoBoravista = " - ";

            if (student.MjestoStanovanja == null)
                student.MjestoStanovanja = " - ";

            if (student.Mail == null)
                student.Mail = " - ";

            if (student.MatBr == null)
                student.MatBr = " - ";

            if (student.IBANRacuna == null)
                student.IBANRacuna = " - ";

            if (student.ServisClanstvoDoDatum == null)
                student.ServisClanstvoDoDatum = " - ";
        }






        public void ContractsValidation(object con)
        {
            var contract = con as List<Contracts>;

            contract.ForEach(x =>
            {
                x.IsplacenoStudentu = x.IsplacenoStudentu.GetValueOrDefault(0);

                if (x.DatumZatvaranjaRacuna == null)
                    x.DatumZatvaranjaRacuna = " - ";

                if (x.RacunDatum == null)
                    x.RacunDatum = " - ";

                x.Porez = x.Porez.GetValueOrDefault(0);
                x.Prirez = x.Prirez.GetValueOrDefault(0);


            });
        }









    }//class end
}
