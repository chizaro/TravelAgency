using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.Web.Areas.Admin.Models.Tours
{
    public class TourEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Название* ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(100, ErrorMessage = "Максимальная длина - 100 символов")]
        public string Name { get; set; }

        [DisplayName("Цена* ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        public int Price { get; set; }

        [DisplayName("Город отправления* ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(100, ErrorMessage = "Максимальная длина - 100 символов")]
        public string DepartureCity { get; set; }

        [DisplayName("Дата отправления* ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDate { get; set; } = DateTime.Now;

        [DisplayName("Дата прибытия* ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalDate { get; set; } = DateTime.Now;

        [DisplayName("Короткое описание тура* ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(1000, ErrorMessage = "Максимальная длина - 1000 символов")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [DisplayName("Тип тура* ")]
        public int TourTypeId { get; set; }

        public IList<TourType> TourTypes { get; set; }

        [DisplayName("Отель ")]
        public int HotelId { get; set; }

        public List<Hotel> Hotels { get; set; } = new List<Hotel> { new Hotel { Name = string.Empty } };

        [DisplayName("Страна ")]
        public int CountryId { get; set; }

        public List<Country> Countries { get; set; } = new List<Country> { new Country { Name = string.Empty } };

        [DisplayName("Скидка ")]
        public int SaleId { get; set; }

        public List<Sale> Sales { get; set; } = new List<Sale> { new Sale { Name = string.Empty } };

        [DisplayName("Страница тура ")]
        [Remote("IsTourPageAvailable", "Tours", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Данная страница уже используется")]
        public int TourPageId { get; set; }

        public List<TourPage> TourPages { get; set; } = new List<TourPage> { new TourPage { Title = string.Empty } };
    }
}