using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Index()
        {
            var countries = countryRepository.GetAll();
            return View(new CountriesViewModel { Countries = countries });
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