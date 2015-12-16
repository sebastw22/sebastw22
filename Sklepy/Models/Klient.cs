using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sklepy.Models
{
    public class Klient
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string mail { get; set; }

        public virtual ICollection<Klient_has_Sklep> Klient_has_Skleps { get; set; }
    }
}
