﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    public class HotelsController : Controller
    {
        // GET: Admin/Hotels
        public ActionResult Index()
        {
            return View();
        }
    }
}