using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Areas.Admin.Models.Hotels;
using static TravelAgency.Business.Constants;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelRepository hotelRepository;
        private readonly IHotelTypeRepository hotelTypeRepository;
        private readonly IFoodRepository foodRepository;

        private readonly IMapper mapper;

        public HotelsController(IHotelRepository hotelRepository, IHotelTypeRepository hotelTypeRepository, IFoodRepository foodRepository, IMapper mapper)
        {
            this.hotelRepository = hotelRepository;
            this.hotelTypeRepository = hotelTypeRepository;
            this.foodRepository = foodRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index(int page = 0)
        {
            var (hotels, count) = hotelRepository.GetPyPage(page, Paging.DefaultPagingSize, hotel => hotel.Name, QueryOrder.Asc,
                include => include.HotelType, inc => inc.Food);

            int totalPages = PageCounter.CountTotalPages(count, Paging.DefaultPagingSize);
            if (page > totalPages || page < 0)
                return HttpNotFound();

            var hotelsViewModel = new HotelsViewModel
            {
                Hotels = hotels,
                PageNumber = page,
                TotalPages = totalPages
            };
            return View(hotelsViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var hotelViewModel = new HotelCreateViewModel
            {
                HotelTypes = hotelTypeRepository.GetAll(),
                Food = foodRepository.GetAll()
            };
            return View(hotelViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotelCreateViewModel hotelViewModel)
        {
            if (!ModelState.IsValid)
                return View(hotelViewModel);

            var hotel = mapper.Map<Hotel>(hotelViewModel);
            hotelRepository.Save(hotel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var hotel = hotelRepository.Get(id);
            if (hotel == null)
                return HttpNotFound();

            var hotelEditModel = mapper.Map<HotelEditViewModel>(hotel);
            hotelEditModel.HotelTypes = hotelTypeRepository.GetAll();
            hotelEditModel.Food = foodRepository.GetAll();

            return View(hotelEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HotelEditViewModel hotelViewModel)
        {
            if (!ModelState.IsValid)
                return View(hotelViewModel);

            var hotel = mapper.Map<Hotel>(hotelViewModel);
            hotelRepository.Update(hotel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            hotelRepository.Delete(id);
            return Json(true);
        }
    }
}