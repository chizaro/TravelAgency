using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Areas.Admin.Models.HotelTypes;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    public class HotelTypesController : Controller
    {
        private readonly IHotelTypeRepository hotelTypeRepository;
        private readonly IMapper mapper;

        public HotelTypesController(IHotelTypeRepository hotelTypeRepository, IMapper mapper)
        {
            this.hotelTypeRepository = hotelTypeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var types = hotelTypeRepository.GetAll();
            return View(new HotelTypesViewModel { HotelTypes = types });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotelTypeCreateViewModel typeViewModel)
        {
            if (!ModelState.IsValid)
                return View(typeViewModel);

            var type = mapper.Map<HotelType>(typeViewModel);
            hotelTypeRepository.Save(type);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var type = hotelTypeRepository.Get(id);
            if (type == null)
                return HttpNotFound();

            var typeEditModel = mapper.Map<HotelTypeEditViewModel>(type);
            return View(typeEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HotelTypeEditViewModel typeViewModel)
        {
            if (!ModelState.IsValid)
                return View(typeViewModel);

            var type = mapper.Map<HotelType>(typeViewModel);
            hotelTypeRepository.Update(type);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            hotelTypeRepository.Delete(id);
            return Json(true);
        }
    }
}