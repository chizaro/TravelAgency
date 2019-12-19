using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.Web.Areas.Admin.Models.Food;

namespace TravelAgency.Web.AutoMapperProfiles
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<FoodCreateViewModel, Food>();
            CreateMap<FoodEditViewModel, Food>();
            CreateMap<Food, FoodEditViewModel>();
        }
    }
}