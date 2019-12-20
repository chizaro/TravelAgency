using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Web.Areas.Admin.Models.Food
{
    public class FoodViewModel
    {
        public IList<TravelAgency.DataAccessLayer.Entities.Food> Food { get; set; }
    }
}