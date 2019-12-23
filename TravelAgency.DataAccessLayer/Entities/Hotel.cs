using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataAccessLayer.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Class { get; set; }
        public string Description { get; set; }
        public int HotelTypeId { get; set; }
        public virtual HotelType HotelType { get; set; }
        public int? FoodId { get; set; }
        public virtual Food Food { get; set; }
    }
}
