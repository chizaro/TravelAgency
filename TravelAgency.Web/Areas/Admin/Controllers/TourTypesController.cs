using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Areas.Admin.Models.TourTypes;
using static TravelAgency.Business.Constants;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    public class TourTypesController : Controller
    {
        private readonly ITourTypeRepostiory tourTypeRepository;
        private readonly IMapper mapper;

        public TourTypesController(ITourTypeRepostiory tourTypeRepository, IMapper mapper)
        {
            this.tourTypeRepository = tourTypeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index(int page = 0)
        {
            var (tourTypes, count) = tourTypeRepository.GetPyPage(page, Paging.DefaultPagingSize);

            int totalPages = PageCounter.CountTotalPages(count, Paging.DefaultPagingSize);
            if (page > totalPages || page < 0)
                return HttpNotFound();

            var tourTypesViewModel = new TourTypesViewModel
            {
                TourTypes = tourTypes,
                PageNumber = page,
                TotalPages = totalPages
            };
            return View(tourTypesViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TourTypeCreateViewModel typeViewModel)
        {
            if (!ModelState.IsValid)
                return View(typeViewModel);

            var tourType = mapper.Map<TourType>(typeViewModel);
            tourTypeRepository.Save(tourType);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tourType = tourTypeRepository.Get(id);
            if (tourType == null)
                return HttpNotFound();

            var typeEditModel = mapper.Map<TourTypeEditViewModel>(tourType);
            return View(typeEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TourTypeEditViewModel typeViewModel)
        {
            if (!ModelState.IsValid)
                return View(typeViewModel);

            var tourType = mapper.Map<TourType>(typeViewModel);
            tourTypeRepository.Update(tourType);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            tourTypeRepository.Delete(id);
            return Json(true);
        }
    }
}