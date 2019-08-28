using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("ShopperApartments")]
    public class ShopperApartment
    {

        [Key,ForeignKey("ApartmentOf"),Column(Order =0)]
        public int ApartmentId { get; set; }
        public virtual Apartment ApartmentOf { get; set; }

        [Key, ForeignKey("ShopperOf"), Column(Order = 1)]
        public int ShopperId { get; set; }
        public virtual Shopper ShopperOf { get; set; }

    }
}
