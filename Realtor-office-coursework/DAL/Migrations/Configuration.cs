namespace DAL.Migrations
{
    using DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Entities.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Entities.EFContext context)
        {
            context.Realtors.AddOrUpdate(t => t.Id, new Realtor()
            {
                Id = 1,
                Name = "Vadim Zakharchuk",
                Password = "F4F4"
                        
            });
        }
    }
}
