using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataAccessLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsCanceled { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
