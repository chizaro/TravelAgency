using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Areas.Admin.Models.Hotels;

namespace TravelAgency.Web.AutoMapperProfiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<HotelCreateViewModel, Hotel>()
                .AfterMap((source, dest) => dest.FoodId = dest.FoodId == 0 ? null : dest.FoodId)
                .ForMember(h => h.Food, opt => opt.Ignore());

            CreateMap<HotelEditViewModel, Hotel>()
                .AfterMap((source, dest) => dest.FoodId = dest.FoodId == 0 ? null : dest.FoodId)
                .ForMember(h => h.Food, opt => opt.Ignore());

            CreateMap<Hotel, HotelEditViewModel>()
                .AfterMap((source, dest) => dest.HotelTypes = DependencyResolver.Current.GetService<IHotelTypeRepository>().GetAll())
                .AfterMap((source, dest) => dest.Food.AddRange(DependencyResolver.Current.GetService<IFoodRepository>().GetAll()))
                .ForMember(h => h.Food, opt => opt.Ignore());
        }
    }
}