namespace _2.Dönem_2.Sinav_Ayberk_Güven_9061.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_2.Dönem_2.Sinav_Ayberk_Güven_9061.Context.BootstrapShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_2.Dönem_2.Sinav_Ayberk_Güven_9061.Context.BootstrapShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
