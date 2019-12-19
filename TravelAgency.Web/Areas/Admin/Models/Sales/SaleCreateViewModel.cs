using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelAgency.Web.Areas.Admin.Models.Sales
{
    public class SaleCreateViewModel
    {
        [DisplayName("Название: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(100, ErrorMessage = "Максимальная длина - 100 символов")]
        public string Name { get; set; }


        [DisplayName("Размер(%): ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [Range(5, 50, ErrorMessage = "Скидка должна быть в диапазоне от 5 до 50%")]
        public double Size { get; set; }
    }
}