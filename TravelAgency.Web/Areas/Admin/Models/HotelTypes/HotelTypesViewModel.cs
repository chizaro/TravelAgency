using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.Web.Areas.Admin.Models.HotelTypes
{
    public class HotelTypesViewModel
    {
        public IList<HotelType> HotelTypes { get; set; }
    }
}