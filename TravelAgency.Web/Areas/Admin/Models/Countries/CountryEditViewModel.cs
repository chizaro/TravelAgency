using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Web.Areas.Admin.Models.Countries
{
    public class CountryEditViewModel : CountryCreateViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
    }
}