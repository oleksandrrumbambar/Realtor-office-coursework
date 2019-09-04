using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class EFContext : DbContext
    {

        public EFContext() : base("Connection")
        { }


        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Realtor> Realtors { get; set; }
        public DbSet<Shopper> Shoppers { get; set; }
        public DbSet<ShopperApartment> ShopperApartment { get; set; }

    }
}