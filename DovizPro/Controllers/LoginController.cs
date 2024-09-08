using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using BusinessLayer.Validation;
using FluentValidation.Results;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Web.Security;

namespace DovizPro.Controllers
{
    [AllowAnonymous] //Authorize etiketi dışında tutmak için kullanılır.
    public class LoginController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User p)
        {
            var a=um.UserRegister(p.Gmail, p.Password);
            if (a != null)
            {
                FormsAuthentication.SetAuthCookie(a.Gmail, false);
                Session["Gmail"] = a.Gmail;
                Session["Name"] = a.Name;
                Session["SurName"] = a.SurName;
                return View("Kullanıcı girişi başarılı");
            }
            else
            {
                ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!!!";
            }
            return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult SignUp() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User p)
        {
            UserValidator uservalide = new UserValidator();
            ValidationResult result = uservalide.Validate(p);
            if (result.IsValid)
            {
                um.UserAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            return View();
        }
    }
}