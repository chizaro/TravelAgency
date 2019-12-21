using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Web.Areas.Admin.Models.TourPages
{
    public class TourPageCreateViewModel
    {
        [DisplayName("Название: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(200, ErrorMessage = "Максимальная длина - 200 символов")]
        public string Title { get; set; }

        [DisplayName("Url: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(1900, ErrorMessage = "Максимальная длина url - 1900 символов")]
        [RegularExpression(@"[a-zа-я0-9-_іїє]+", ErrorMessage = "Url может содержать только буквы в нижнем регистре, цифры, символы '-' и '_'")]
        //[Remote("IsUrlAvailable", "TourPages", HttpMethod = "POST", ErrorMessage = "Данный url уже используется")]
        public string Url { get; set; }

        [DisplayName("Основной контент: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [AllowHtml]
        public string Description { get; set; }
    }
}