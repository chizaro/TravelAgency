using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Areas.Admin.Models.Sales;
using static TravelAgency.Business.Constants;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Tour manager")]
    public class SalesController : Controller
    {
        private readonly ISaleRepository saleRepository;
        private readonly IMapper mapper;

        public SalesController(ISaleRepository saleRepository, IMapper mapper)
        {
            this.saleRepository = saleRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index(int page = 0)
        {
            var (sales, count) = saleRepository.GetPyPage(page, Paging.DefaultPagingSize, s => s.Size, QueryOrder.Desc);

            int totalPages = PageCounter.CountTotalPages(count, Paging.DefaultPagingSize);
            if (page > totalPages || page < 0)
                return HttpNotFound();

            var countriesViewModel = new SalesViewModel
            {
                Sales = sales,
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
        public ActionResult Create(SaleCreateViewModel saleViewModel)
        {
            if (!ModelState.IsValid)
                return View(saleViewModel);

            var sale = mapper.Map<Sale>(saleViewModel);
            saleRepository.Save(sale);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sale = saleRepository.Get(id);
            if (sale == null)
                return HttpNotFound();

            var saleEditModel = mapper.Map<SaleEditViewModel>(sale);
            return View(saleEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaleEditViewModel saleViewModel)
        {
            if (!ModelState.IsValid)
                return View(saleViewModel);

            var sale = mapper.Map<Sale>(saleViewModel);
            saleRepository.Update(sale);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            saleRepository.Delete(id);
            return Json(true);
        }
    }
}