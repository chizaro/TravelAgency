using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.Business.Tours;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Models.TourPages;
using TravelAgency.Web.Models.Tours;
using static TravelAgency.Business.Constants;

namespace TravelAgency.Web.Controllers
{
    public class ToursController : Controller
    {
        private readonly ITourRepository tourRepository;
        private readonly ITourPageRepository tourPageRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public ToursController(ITourRepository tourRepository, ITourPageRepository tourPageRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            this.tourRepository = tourRepository;
            this.tourPageRepository = tourPageRepository;
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult List(ToursViewModel viewModel, int page = 0)
        {
            var (tours, count) = tourRepository.GetPyPage(page, Paging.ToursPagingSize, viewModel.CountryId, viewModel.DateFrom, viewModel.DateTo);

            int totalPages = PageCounter.CountTotalPages(count, Paging.ToursPagingSize);
            if (page > totalPages || page < 0)
                return HttpNotFound();

            var toursViewModel = new ToursViewModel
            {
                Tours = TourPriceSetter.SetPriceWithSale(tours),
                PageNumber = page,
                TotalPages = totalPages
            };
            toursViewModel.Countries.AddRange(countryRepository.GetAll());
            return View(toursViewModel);
        }

        [HttpGet]
        public ActionResult Details(string url)
        {
            var page = tourPageRepository.GetByUrl(url);
            if (page == null)
                return HttpNotFound();

            var pageViewModel = mapper.Map<TourPageViewModel>(page);
            pageViewModel.TourId = tourRepository.GetByTourPageId(page.Id).Id;

            return View(pageViewModel);
        }
    }
}