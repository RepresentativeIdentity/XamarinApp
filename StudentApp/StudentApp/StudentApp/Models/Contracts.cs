using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Models
{
    public class Contracts
    {

        public string BpCodeTvrtka { get; set; }

        public string BpNameTvrtka { get; set; }

        public DateTime DatumIzdavanja { get; set; }

        public decimal? IznosNeto { get; set; }

        public decimal? IsplacenoStudentu { get; set; }



        //dodatno za ContractDetails
        public string UgovorBroj { get; set; }

        public string RacunDatum { get; set; }

        public string DatumZatvaranjaRacuna { get; set; }

        public decimal? Porez { get; set; }

        public decimal? Prirez { get; set; }
    }
}
