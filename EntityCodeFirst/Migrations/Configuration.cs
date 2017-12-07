namespace EntityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ClassLibraryProjet;

    internal sealed class Configuration : DbMigrationsConfiguration<ClassLibraryProjet.SaladesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EntityCodeFirst.SaladesContext";
        }

        protected override void Seed(ClassLibraryProjet.SaladesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
