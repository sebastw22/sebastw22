//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sklepy.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Klient_has_Sklep
    {
        public int Klient_has_Sklep1 { get; set; }
        public int SklepID { get; set; }
        public int KlientID { get; set; }
        public string Znizka1 { get; set; }
        public string Znizka2 { get; set; }
        public string Znizka3 { get; set; }
    
        public virtual Klient Klient { get; set; }
        public virtual Sklep Sklep { get; set; }
    }
}
