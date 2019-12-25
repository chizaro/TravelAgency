using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelAgency.Business.Security;
using TravelAgency.DataAccessLayer.Repositories;
using TravelAgency.Web.Areas.Admin.Models.Account;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAdminRepository adminRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;

        public AccountController(IAdminRepository adminRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            this.adminRepository = adminRepository;
            this.roleRepository = roleRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel admin)
        {
            if (!ModelState.IsValid)
                return View(admin);

            var existedAdmin = adminRepository.GetByLogin(admin.Login);
            if (existedAdmin == null)
            {
                ModelState.AddModelError("Login", "Пользователь с таким логином не найден");
                return View();
            }

            var hashing = new Hashing();
            hashing.GenerateHash(admin.Password);
            if (!hashing.VerifyHash(existedAdmin.Hash))
            {
                ModelState.AddModelError("Password", "Неверный пароль");
                return View();
            }
            CreateTicket(admin.Login, existedAdmin.Role?.Name ?? string.Empty);
            return RedirectToAction("Index", "Countries");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return View(registerViewModel);

            var hashing = new Hashing();
            hashing.GenerateHash(registerViewModel.Password);

            var admin = mapper.Map<TravelAgency.DataAccessLayer.Entities.Admin>(registerViewModel);
            admin.Hash = hashing.HashCode;
            adminRepository.Save(admin);

            CreateTicket(registerViewModel.Login, string.Empty);
            return RedirectToAction("Index", "Tours");
        }

        [HttpGet]
        public JsonResult IsUserExist(string login)
        {
            return Json(!adminRepository.IsExist(login), JsonRequestBehavior.AllowGet);
        }

        private void CreateTicket(string login, string role)
        {
            var ticket = new FormsAuthenticationTicket(
                    version: 1,
                    name: login,
                    issueDate: DateTime.Now,
                    expiration: DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                    isPersistent: true,
                    userData: role);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                Expires = ticket.Expiration
            };
            HttpContext.Response.Cookies.Add(cookie);
        }
    }
}