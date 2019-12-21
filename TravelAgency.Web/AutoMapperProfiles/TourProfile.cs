using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.Web.Areas.Admin.Models.Tours;

namespace TravelAgency.Web.AutoMapperProfiles
{
    public class TourProfile : Profile
    {
        public TourProfile()
        {
            CreateMap<TourEditViewModel, Tour>().AfterMap((source, dest) => MapTour(dest));
            CreateMap<Tour, TourEditViewModel>();
        }

        private static void MapTour(Tour tour)
        {
            tour.CountryId = tour.CountryId == 0 ? null : tour.CountryId;
            tour.HotelId = tour.HotelId == 0 ? null : tour.HotelId;
            tour.SaleId = tour.SaleId == 0 ? null : tour.SaleId;
            tour.TourPageId = tour.TourPageId == 0 ? null : tour.TourPageId;
        }
    }
}