using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.Web.Areas.Admin.Models.TourPages
{
    public class TourPagesViewModel
    {
        public IList<TourPage> TourPages { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
    }
}