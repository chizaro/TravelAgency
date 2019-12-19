using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.Web.Areas.Admin.Models.Sales
{
    public class SalesViewModel
    {
        public IList<Sale> Sales { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
    }
}