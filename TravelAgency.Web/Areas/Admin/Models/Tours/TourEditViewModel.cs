using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Web.Areas.Admin.Models.Tours
{
    public class TourEditViewModel : TourCreateViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string ImageName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImagePath { get; set; }
    }
}