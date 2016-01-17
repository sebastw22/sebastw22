using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklepy.Models.DB;

namespace Sklepy.Models.ViewModel
{
    public class Klient_has_SklepIndexData
    /* {
         public IEnumerable<Klient> Klients { get; set; }
          public IEnumerable<Klient_has_Sklep> Klient_has_Skleps {get; set;}
    }*/



    {
        public IList<Klient> Klients { get; set; }
        public IList<Klient_has_Sklep> Klient_has_Skleps { get; set; }

        public IEnumerable<Sklep> Skleps { get; set; }  //dopisane

        public Klient_has_SklepIndexData()
        {
            Klients = new List<Klient>();
            Klient_has_Skleps = new List<Klient_has_Sklep>();
        }

    }

}
