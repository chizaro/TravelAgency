using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelAgency.Web.Areas.Admin.Models.Food
{
    public class FoodCreateViewModel
    {
        [DisplayName("Название: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(100, ErrorMessage = "Максимальная длина - 100 символов")]
        public string Name { get; set; }

        [DisplayName("Описание: ")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}