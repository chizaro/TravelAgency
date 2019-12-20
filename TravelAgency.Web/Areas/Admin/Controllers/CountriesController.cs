using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.Business;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.EntityFramework;
using TravelAgency.EntityFramework.Repositories;
using TravelAgency.Web.App_Start;
using TravelAgency.Web.Areas.Admin.Models.Countries;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public CountriesController(ICountryRepository countryRepository, IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index(int page = 0)
        {
            var (countries, count) = countryRepository.GetPyPage(page, Constants.Paging.DefaultPagingSize);

            int totalPages = PageCounter.CountTotalPages(count, Constants.Paging.DefaultPagingSize);
            if (page > totalPages || page < 0)
                return HttpNotFound();

            var countriesViewModel = new CountriesViewModel
            {
                Countries = countries,
                PageNumber = page,
                TotalPages = totalPages
            };
            return View(countriesViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryCreateViewModel countryViewModel)
        {
            if (!ModelState.IsValid)
                return View(countryViewModel);

            var country = mapper.Map<Country>(countryViewModel);
            countryRepository.Save(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var country = countryRepository.Get(id);
            if (country == null)
                return HttpNotFound();

            var countryEditModel = mapper.Map<CountryEditViewModel>(country);
            return View(countryEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryEditViewModel countryViewModel)
        {
            if (!ModelState.IsValid)
                return View(countryViewModel);

            var country = mapper.Map<Country>(countryViewModel);
            countryRepository.Update(country);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            countryRepository.Delete(id);
            return Json(true);
        }
    }
}