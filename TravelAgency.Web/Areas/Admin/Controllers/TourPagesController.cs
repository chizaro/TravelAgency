using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Areas.Admin.Models.TourPages;
using static TravelAgency.Business.Constants;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Tour manager")]
    public class TourPagesController : Controller
    {
        private readonly ITourPageRepository tourPageRepository;
        private readonly IMapper mapper;

        public TourPagesController(ITourPageRepository tourPageRepository, IMapper mapper)
        {
            this.tourPageRepository = tourPageRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index(int page = 0)
        {
            var (pages, count) = tourPageRepository.GetPyPage(page, Paging.DefaultPagingSize);

            int totalPages = PageCounter.CountTotalPages(count, Paging.DefaultPagingSize);
            if (page > totalPages || page < 0)
                return HttpNotFound();

            var pagesViewModel = new TourPagesViewModel
            {
                TourPages = pages,
                PageNumber = page,
                TotalPages = totalPages
            };
            return View(pagesViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TourPageCreateViewModel pageViewModel)
        {
            if (!ModelState.IsValid)
                return View(pageViewModel);

            var page = mapper.Map<TourPage>(pageViewModel);
            tourPageRepository.Save(page);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var page = tourPageRepository.Get(id);
            if (page == null)
                return HttpNotFound();

            var pageEditModel = mapper.Map<TourPageEditViewModel>(page);
            return View(pageEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TourPageEditViewModel pageViewModel)
        {
            if (!ModelState.IsValid)
                return View(pageViewModel);

            var page = mapper.Map<TourPage>(pageViewModel);
            tourPageRepository.Update(page);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            tourPageRepository.Delete(id);
            return Json(true);
        }
    }
}