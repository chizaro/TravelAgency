using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.Web.Areas.Admin.Models.Tours
{
    public class ToursViewModel
    {
        public IList<Tour> Tours { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
    }
}