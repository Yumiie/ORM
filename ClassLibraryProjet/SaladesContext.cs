using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryProjet
{
    public class SaladesContext : DbContext
    {
        public SaladesContext()
            :base ("salades") //je donne le nom de la chaine de connexion
        {

        }
        //je défini mes DbSet ( qui sont mappés aux tables )
        public virtual DbSet<Salade> Salades { get; set; }

        public System.Data.Entity.DbSet<ClassLibraryProjet.Fabricant> Fabricants { get; set; }

        public System.Data.Entity.DbSet<ClassLibraryProjet.Magasin> Magasins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
