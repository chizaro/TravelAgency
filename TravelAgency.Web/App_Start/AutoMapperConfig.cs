using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.Web.AutoMapperProfiles;

namespace TravelAgency.Web.App_Start
{
    public class AutoMapperConfig
    {
        public MapperConfiguration Configure()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CountryProfile>();
                cfg.AddProfile<SaleProfile>();
                cfg.AddProfile<FoodProfile>();
                cfg.AddProfile<HotelTypeProfile>();
                cfg.AddProfile<HotelProfile>();
                cfg.AddProfile<TourTypeProfile>();
                cfg.AddProfile<AdminProfile>();
                cfg.AddProfile<TourPageProfile>();
                cfg.AddProfile<TourProfile>();
                cfg.AddProfile<OrderProfile>();
            });

            return configuration;
        }

    }
}