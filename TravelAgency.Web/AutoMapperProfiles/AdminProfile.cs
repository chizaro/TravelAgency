using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.Web.Areas.Admin.Models.Account;
using TravelAgency.Web.Areas.Admin.Models.Admin;

namespace TravelAgency.Web.AutoMapperProfiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<RegisterViewModel, Admin>();
            CreateMap<AdminEditViewModel, Admin>();
            CreateMap<Admin, AdminEditViewModel>();
        }
    }
}