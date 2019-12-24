using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Web.Models.TourPages
{
    public class TourPageViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TourId { get; set; }
    }
}