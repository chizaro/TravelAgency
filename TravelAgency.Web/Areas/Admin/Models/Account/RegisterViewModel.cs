using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace TravelAgency.Web.Areas.Admin.Models.Account
{
    public class RegisterViewModel
    {
        [DisplayName("Логин")]
        [Required]
        [StringLength(50, ErrorMessage = "Login не должен превышать 50 символов")]
        [Remote("IsUserExist", "Account", "Admin", HttpMethod = "GET", ErrorMessage = "Пользователь с таким именем уже существует")]
        public string Login { set; get; }

        [DisplayName("Имя")]
        [Required]
        [StringLength(100, ErrorMessage = "Максимальная длина - 100 символов")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        [Required]
        [StringLength(100, ErrorMessage = "Максимальная длина - 100 символов")]
        public string LastName { get; set; }

        [DisplayName("Пароль")]
        [Required]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля - 6 символов")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [DisplayName("Подтвердить пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}