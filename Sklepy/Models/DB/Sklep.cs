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
    
    public partial class Sklep
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sklep()
        {
            this.Klient_has_Sklep = new HashSet<Klient_has_Sklep>();
            this.Sklep_has_Produkt = new HashSet<Sklep_has_Produkt>();
            this.Sklep_has_Miejsce = new HashSet<Sklep_has_Miejsce>();
        }
    
        public int SklepID { get; set; }
        public string Nazwa { get; set; }
        public Nullable<int> Numer { get; set; }
        public string Telefon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Klient_has_Sklep> Klient_has_Sklep { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sklep_has_Produkt> Sklep_has_Produkt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sklep_has_Miejsce> Sklep_has_Miejsce { get; set; }
    }
}
