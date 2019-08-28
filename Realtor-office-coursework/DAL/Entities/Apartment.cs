using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Apartments")]
    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public double Square { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CountRooms { get; set; }
        [Required]
        public bool Bought { get; set; }

        [ForeignKey("RealtorOf")]
        public int RealtorId { get; set; }
        public virtual Realtor RealtorOf { get; set; }
        public virtual ICollection<ShopperApartment> ShopperApartments { set; get; }


    }
}
