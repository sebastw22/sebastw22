using Sklepy.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Sklepy.DAL
{
    public class SklepyContext : DbContext
    {
        public SklepyContext() : base("SklepyContext")
        {
        }

        public DbSet<Klient> Klients { get; set; }
        public DbSet<Sklep> Skleps { get; set; }
        public DbSet<Klient_has_Sklep> Klient_has_Skleps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
