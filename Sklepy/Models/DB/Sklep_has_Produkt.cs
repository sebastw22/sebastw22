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
    
    public partial class Sklep_has_Produkt
    {
        public int Sklep_has_MiejsceID { get; set; }
        public int SklepID { get; set; }
        public int ProduktID { get; set; }
    
        public virtual Produkt Produkt { get; set; }
        public virtual Sklep Sklep { get; set; }
    }
}