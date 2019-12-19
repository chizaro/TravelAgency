using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Web.Areas.Admin.Models.Sales
{
    public class SaleEditViewModel : SaleCreateViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
    }
}