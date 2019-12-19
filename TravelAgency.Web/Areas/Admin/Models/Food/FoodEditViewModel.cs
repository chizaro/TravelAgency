using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Web.Areas.Admin.Models.Food
{
    public class FoodEditViewModel : FoodCreateViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
    }
}