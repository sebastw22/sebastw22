using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Sklepy.Models;

namespace Sklepy.DAL
{
    class SklepyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SklepyContext>
    {
        protected override void Seed(SklepyContext context)
    {
        var klients = new List<Klient>
            {
                new Klient {Imie="Marek",Nazwisko="Grechuta", Adres="Latoszyn 152a", mail="marek@grechuta.pl", Telefon="654456545", },
                new Klient {Imie="Rysiek",Nazwisko="Zając", Adres="Latoszyn 12a", mail="rychu@zajac.pl", Telefon="654111345", }
            };
        klients.ForEach(s => context.Klients.Add(s));
        context.SaveChanges();

        var skleps = new List<Sklep>
            {
                new Sklep{ID=7, Nazwa="H&M", Numer=7, Telefon="146816478", },
                new Sklep {ID=8, Nazwa="Cropp", Numer=8, Telefon="146816479", }
            };
        skleps.ForEach(s => context.Skleps.Add(s));
        context.SaveChanges();

        var klient_has_skleps = new List<Klient_has_Sklep>
            {
            new Klient_has_Sklep { KlientID=1, SklepID=7, znizka1=10},
            new Klient_has_Sklep {KlientID=1, SklepID=8, znizka1=5 },
            new Klient_has_Sklep {KlientID=2, SklepID=7, znizka2=10 },
            };
        klient_has_skleps.ForEach(s => context.Klient_has_Skleps.Add(s));
        context.SaveChanges();

    }
}


}
