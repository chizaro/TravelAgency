using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.Business;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Areas.Admin.Models.Orders;
using static TravelAgency.Business.Constants;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult Index(int page = 0)
        {
            var (orders, count) = orderRepository.GetPyPage(page, Paging.DefaultPagingSize, inc => inc.Tour);

            int totalPages = PageCounter.CountTotalPages(count, Paging.DefaultPagingSize);
            if (page > totalPages || page < 0)
                return HttpNotFound();

            var countriesViewModel = new OrdersViewModel
            {
                Orders = orders,
                PageNumber = page,
                TotalPages = totalPages
            };
            return View(countriesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            orderRepository.Delete(id);
            return Json(true);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Cancel(int id)
        {
            var order = orderRepository.Get(id);
            if (order == null)
                return Json(false);

            order.IsCanceled = true;
            orderRepository.Update(order);
            return Json(true);
        }

        [HttpGet]
        public FileResult CreateReport(DateTime date)
        {
            var orders = orderRepository.GetByDate(date, incl => incl.Tour);
            string fileName = string.Concat("Заказы за ", date.ToShortDateString(), ".pdf");
            string path = PdfSaver.SaveOrder(orders, HttpContext.Server.MapPath("/Content/Reports/"), fileName);

            return File(path, "application/pdf", fileName);
        }
    }
}