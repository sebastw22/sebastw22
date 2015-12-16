using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sklepy.Models
{
    public class Sklep
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public int Numer { get; set; }
        public string Telefon { get; set; }

        public virtual ICollection<Klient_has_Sklep> Klient_Has_Skleps { get; set; }
    }
}
