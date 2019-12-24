using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.Web.Areas.Admin.Models.Orders
{
    public class OrdersViewModel
    {
        public IList<Order> Orders { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}