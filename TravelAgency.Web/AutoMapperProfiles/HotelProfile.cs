using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.Web.Areas.Admin.Models.Hotels;

namespace TravelAgency.Web.AutoMapperProfiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<HotelCreateViewModel, Hotel>().ForMember(h => h.Food, opt => opt.Ignore());
            CreateMap<HotelEditViewModel, Hotel>().ForMember(h => h.Food, opt => opt.Ignore());
            CreateMap<Hotel, HotelEditViewModel>().ForMember(h => h.Food, opt => opt.Ignore());
        }
    }
}