using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer.Entities;
using FoodItem = TravelAgency.DataAccessLayer.Entities.Food;

namespace TravelAgency.Web.Areas.Admin.Models.Hotels
{
    public class HotelCreateViewModel
    {
        [DisplayName("Название: ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(200, ErrorMessage = "Максимальная длина - 200 символов")]
        public string Name { get; set; }

        [DisplayName("Класс отеля (кол-во звёзд): ")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [Range(1, 5, ErrorMessage = "Значение должно быть в диапазоне от 1 до 5")]
        public byte Class { get; set; } = 1;

        [DisplayName("Описание: ")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Тип отеля: ")]
        public int HotelTypeId { get; set; }
        
        public IList<HotelType> HotelTypes { get; set; }

        [DisplayName("Питание: ")]
        public int FoodId { get; set; }

        public List<FoodItem> Food { get; set; } = new List<FoodItem> { new FoodItem { Name = string.Empty } };
    }
}