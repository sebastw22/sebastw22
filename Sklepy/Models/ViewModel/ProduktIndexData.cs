using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklepy.Models.DB;

namespace Sklepy.Models.ViewModel
{
    public class ProduktIndexData
    {
        //public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Miejsce> Miejsces { get; set; }
        public IEnumerable<Sklep> Skleps { get; set; }
        public IEnumerable<Produkt> Produkts { get; set; }
        public IEnumerable<Sklep_has_Miejsce> Sklep_has_Miejsces { get; set; }
        public IEnumerable<Sklep_has_Produkt> Sklep_has_Produkts { get; set; }
    }
}
