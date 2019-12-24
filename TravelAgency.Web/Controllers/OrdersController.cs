using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Models.Orders;

namespace TravelAgency.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrdersController(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var orderViewModel = new OrderViewModel
            {
                TourId = id
            };
            return PartialView(orderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(OrderViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return Json(false);

            var order = mapper.Map<Order>(viewModel);
            orderRepository.Save(order);
            return Json(true);
        }
    }
}