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
            context.Apartments.AddOrUpdate(t => t.Id, new Apartment()
            {
                Id = 1,
                Number = "A1",
                Square = 50,
                Price = 45000,
                CountRooms = 2,
                Bought = false
                                             
            });
        }
    }
}
