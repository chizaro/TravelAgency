using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.EntityFramework;
using TravelAgency.EntityFramework.Repositories;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    public class ToursController : Controller
    {
        private readonly ITourRepository tourRepository;

        public ToursController()
        {
            tourRepository = new TourRepository(new TravelAgencyContext());
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Json(tourRepository.GetAll(), JsonRequestBehavior.AllowGet);
        }
    }
}