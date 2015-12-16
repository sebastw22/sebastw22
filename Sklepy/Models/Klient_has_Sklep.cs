using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sklepy.Models
{
    public class Klient_has_Sklep
    {

        public int Klient_has_SklepID { get; set; }
        public int KlientID { get; set; }
        public int SklepID { get; set; }
        public int znizka1 { get; set; }
        public int znizka2 { get; set; }
        public int znizka3 { get; set; }

        public virtual Klient Klient { get; set; }
        public virtual Sklep Sklep { get; set; }
    }
}
