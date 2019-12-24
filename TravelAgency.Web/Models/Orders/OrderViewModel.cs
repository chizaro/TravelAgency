using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Web.Models.Orders
{
    public class OrderViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public DateTime Date { get; set; } = DateTime.Now;

        [DisplayName("Имя: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(100, ErrorMessage = "Максимальная длина - 100 символов")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(100, ErrorMessage = "Максимальная длина - 100 символов")]
        public string LastName { get; set; }

        [DisplayName("Номер телефона: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(20, ErrorMessage = "Некоректный номер телефона")]
        [RegularExpression(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", ErrorMessage = "Некоректный формат номера телефона")]
        public string PhoneNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int TourId { get; set; }
    }
}