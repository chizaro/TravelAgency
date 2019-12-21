using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Web.Areas.Admin.Models.Admin
{
    public class AdminsViewModel
    {
        public IList<TravelAgency.DataAccessLayer.Entities.Admin> Admins { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
    }
}