using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Areas.Admin.Models.Tours;
using static TravelAgency.Business.Constants;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    public class ToursController : Controller
    {
        private readonly ITourRepository tourRepository;
        private readonly ITourTypeRepostiory tourTypeRepostiory;
        private readonly ICountryRepository countryRepository;
        private readonly ISaleRepository saleRepository;
        private readonly IHotelRepository hotelRepository;
        private readonly ITourPageRepository tourPageRepository;
        private readonly IMapper mapper;

        public ToursController(ITourRepository tourRepository, ITourTypeRepostiory tourTypeRepostiory, ICountryRepository countryRepository,
            ISaleRepository saleRepository, IHotelRepository hotelRepository, ITourPageRepository tourPageRepository, IMapper mapper)
        {
            this.tourRepository = tourRepository;
            this.tourTypeRepostiory = tourTypeRepostiory;
            this.countryRepository = countryRepository;
            this.saleRepository = saleRepository;
            this.hotelRepository = hotelRepository;
            this.tourPageRepository = tourPageRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index(int page = 0)
        {
            var (tours, count) = tourRepository.GetPyPage(page, Paging.DefaultPagingSize, t => t.Name, QueryOrder.Asc, inc => inc.Sale);

            int totalPages = PageCounter.CountTotalPages(count, Paging.DefaultPagingSize);
            if (page > totalPages || page < 0)
                return HttpNotFound();

            var toursViewModel = new ToursViewModel
            {
                Tours = tours,
                PageNumber = page,
                TotalPages = totalPages
            };
            return View(toursViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var tourViewModel = new TourEditViewModel();
            FillTourViewModel(tourViewModel);
            return View(tourViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TourEditViewModel tourViewModel)
        {
            if (!ModelState.IsValid)
                return View(tourViewModel);

            var tour = mapper.Map<Tour>(tourViewModel);
            tourRepository.Save(tour);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tour = tourRepository.Get(id);
            if (tour == null)
                return HttpNotFound();

            var tourEditModel = mapper.Map<TourEditViewModel>(tour);
            FillTourViewModel(tourEditModel);
            return View(tourEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TourEditViewModel tourViewModel)
        {
            if (!ModelState.IsValid)
                return View(tourViewModel);

            var tour = mapper.Map<Tour>(tourViewModel);
            tourRepository.Update(tour);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            tourRepository.Delete(id);
            return Json(true);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var tour = tourRepository.Get(id);
            return PartialView("_TourInfo", tour);
        }

        [HttpGet]
        public JsonResult IsTourPageAvailable(int tourPageId, int? id)
        {
            var tour = tourRepository.GetByTourPageId(tourPageId);
            if (tour == null)
                return Json(true, JsonRequestBehavior.AllowGet);

            if (tour.Id == id)
                return Json(true, JsonRequestBehavior.AllowGet);

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        private void FillTourViewModel(TourEditViewModel tourViewModel)
        {
            tourViewModel.TourTypes = tourTypeRepostiory.GetAll();
            tourViewModel.Countries.AddRange(countryRepository.GetAll());
            tourViewModel.Sales.AddRange(saleRepository.GetAll());
            tourViewModel.Hotels.AddRange(hotelRepository.GetAll());
            tourViewModel.TourPages.AddRange(tourPageRepository.GetAll());
        }
    }
}