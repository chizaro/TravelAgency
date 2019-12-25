using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Areas.Admin.Models.Food;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Tour manager")]
    public class FoodController : Controller
    {
        private readonly IFoodRepository foodRepository;
        private readonly IMapper mapper;

        public FoodController(IFoodRepository foodRepository, IMapper mapper)
        {
            this.foodRepository = foodRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var food = foodRepository.GetAll();
            return View(new FoodViewModel { Food = food });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodCreateViewModel foodViewModel)
        {
            if (!ModelState.IsValid)
                return View(foodViewModel);

            var food = mapper.Map<Food>(foodViewModel);
            foodRepository.Save(food);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var food = foodRepository.Get(id);
            if (food == null)
                return HttpNotFound();

            var foodEditModel = mapper.Map<FoodEditViewModel>(food);
            return View(foodEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FoodEditViewModel foodViewModel)
        {
            if (!ModelState.IsValid)
                return View(foodViewModel);

            var food = mapper.Map<Food>(foodViewModel);
            foodRepository.Update(food);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            foodRepository.Delete(id);
            return Json(true);
        }
    }
}