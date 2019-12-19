using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Web.Areas.Admin.Models.HotelTypes
{
    public class HotelTypeEditViewModel : HotelTypeCreateViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
    }
}