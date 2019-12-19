using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelAgency.Web.Areas.Admin.Models.Countries
{
    public class CountryCreateViewModel
    {
        [DisplayName("Страна: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(200, ErrorMessage = "Максимальная длина - 200 символов")]
        public string Name { get; set; }
    }
}