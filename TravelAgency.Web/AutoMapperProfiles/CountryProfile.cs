using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.Web.Areas.Admin.Models.Countries;

namespace TravelAgency.Web.AutoMapperProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryCreateViewModel, Country>();
            CreateMap<CountryEditViewModel, Country>();
            CreateMap<Country, CountryEditViewModel>();
        }
    }
}