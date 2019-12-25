using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Areas.Admin.Models.Account;
using TravelAgency.Web.Areas.Admin.Models.Admin;

namespace TravelAgency.Web.AutoMapperProfiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<RegisterViewModel, Admin>().AfterMap((source, dest) => dest.RoleId = null);
            CreateMap<AdminEditViewModel, Admin>().AfterMap((source, dest) => dest.RoleId = dest.RoleId == 0 ? null : dest.RoleId);
            CreateMap<Admin, AdminEditViewModel>()
                .AfterMap((source, dest) => dest.Roles.AddRange(DependencyResolver.Current.GetService<IRoleRepository>().GetAll()));
        }
    }
}