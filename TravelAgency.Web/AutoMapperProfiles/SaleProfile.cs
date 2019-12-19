using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.Web.Areas.Admin.Models.Sales;

namespace TravelAgency.Web.AutoMapperProfiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<SaleCreateViewModel, Sale>();
            CreateMap<SaleEditViewModel, Sale>();
            CreateMap<Sale, SaleEditViewModel>();
        }
    }
}