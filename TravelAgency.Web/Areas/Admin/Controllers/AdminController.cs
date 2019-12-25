using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Areas.Admin.Models.Admin;
using static TravelAgency.Business.Constants;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminRepository adminRepository;
        private readonly IMapper mapper;

        public AdminController(IAdminRepository adminRepository, IMapper mapper)
        {
            this.adminRepository = adminRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult List(int page = 0)
        {
            var (admins, count) = adminRepository.GetPyPage(page, Paging.DefaultPagingSize);

            int totalPages = PageCounter.CountTotalPages(count, Paging.DefaultPagingSize);
            if (page > totalPages || page < 0)
                return HttpNotFound();

            var countriesViewModel = new AdminsViewModel
            {
                Admins = admins,
                PageNumber = page,
                TotalPages = totalPages
            };
            return View(countriesViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var admin = adminRepository.Get(id);
            if (admin == null)
                return HttpNotFound();

            var adminEditModel = mapper.Map<AdminEditViewModel>(admin);
            return View(adminEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdminEditViewModel adminViewModel)
        {
            if (!ModelState.IsValid)
                return View(adminViewModel);

            var admin = mapper.Map<DataAccessLayer.Entities.Admin>(adminViewModel);
            admin.Hash = adminRepository.GetByLogin(adminViewModel.Login).Hash;
            adminRepository.Update(admin);

            return RedirectToAction("List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            adminRepository.Delete(id);
            return Json(true);
        }
    }
}