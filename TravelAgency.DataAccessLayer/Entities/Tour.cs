using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataAccessLayer.Entities
{
    public class Tour
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public DateTime DepartureDate { get; set; }

        public string DepartureCity { get; set; }

        public DateTime ArrivalDate { get; set; }

        public string ShortDescription { get; set; }

        public int TourTypeId { get; set; }

        public virtual TourType TourType { get; set; }

        public int? HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public int? SaleId { get; set; }

        public virtual Sale Sale { get; set; }

        public int? TourPageId { get; set; }

        public virtual TourPage TourPage { get; set; }
    }
}
