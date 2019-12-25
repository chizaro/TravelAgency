using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.Web.Areas.Admin.Models.Admin
{
    public class AdminEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Логин: ")]
        public string Login { get; set; }

        [DisplayName("Имя: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(100, ErrorMessage = "Максимальная длина - 100 символов")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(100, ErrorMessage = "Максимальная длина - 100 символов")]
        public string LastName { get; set; }

        [DisplayName("Роль: ")]
        public int RoleId { get; set; }

        public List<Role> Roles { get; set; } = new List<Role> { new Role { Name = string.Empty } };
    }
}