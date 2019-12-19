using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Areas.Admin.Models.Sales;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
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
        public ActionResult Index()
        {
            var sales = saleRepository.GetAll();
            return View(new SalesViewModel { Sales = sales });
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