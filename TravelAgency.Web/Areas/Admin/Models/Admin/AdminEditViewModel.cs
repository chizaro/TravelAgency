using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Web.Areas.Admin.Models.Admin
{
    public class AdminEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Логин: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(100, ErrorMessage = "Максимальная длина - 50 символов")]
        public string Login { get; set; }

        [DisplayName("Имя: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(100, ErrorMessage = "Максимальная длина - 100 символов")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(100, ErrorMessage = "Максимальная длина - 100 символов")]
        public string LastName { get; set; }
    }
}