using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.Web.Areas.Admin.Models.TourPages;
using TravelAgency.Web.Models.TourPages;

namespace TravelAgency.Web.AutoMapperProfiles
{
    public class TourPageProfile : Profile
    {
        public TourPageProfile()
        {
            CreateMap<TourPageCreateViewModel, TourPage>();
            CreateMap<TourPageEditViewModel, TourPage>();
            CreateMap<TourPage, TourPageEditViewModel>();
            CreateMap<TourPage, TourPageViewModel>();
        }
    }
}