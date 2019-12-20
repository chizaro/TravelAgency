using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.Web.Areas.Admin.Models.TourTypes;

namespace TravelAgency.Web.AutoMapperProfiles
{
    public class TourTypeProfile : Profile
    {
        public TourTypeProfile()
        {
            CreateMap<TourTypeCreateViewModel, TourType>();
            CreateMap<TourTypeEditViewModel, TourType>();
            CreateMap<TourType, TourTypeEditViewModel>();
        }
    }
}