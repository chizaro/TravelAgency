using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.Web.Areas.Admin.Models.Food;
using TravelAgency.Web.Areas.Admin.Models.HotelTypes;

namespace TravelAgency.Web.AutoMapperProfiles
{
    public class HotelTypeProfile : Profile
    {
        public HotelTypeProfile()
        {
            CreateMap<HotelTypeCreateViewModel, HotelType>();
            CreateMap<HotelTypeEditViewModel, HotelType>();
            CreateMap<HotelType, HotelTypeEditViewModel>();
        }
    }
}