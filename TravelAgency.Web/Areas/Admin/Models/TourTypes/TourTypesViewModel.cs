using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.Web.Areas.Admin.Models.TourTypes
{
    public class TourTypesViewModel
    {
        public IList<TourType> TourTypes { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
    }
}