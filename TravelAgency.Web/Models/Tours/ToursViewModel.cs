using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.Web.Models.Tours
{
    public class ToursViewModel
    {
        public IList<Tour> Tours { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }

        [Display(Name = "Страна")]
        public int CountryId { get; set; }

        public List<Country> Countries { get; set; } = new List<Country> { new Country { Name = "Любая" } };

        [Display(Name = "Дата от")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [Display(Name = "До")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }
    }
}