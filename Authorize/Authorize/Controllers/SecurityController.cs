using Authorize.Context;
using Authorize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Authorize.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        //
        // GET: /Security/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (var db = new AuthorizeDbContext())
            {
                var data = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
                if (data != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Mesaj = "Geçersiz Kullanıcı. Kullanıcı Adı veya Şifre Hatalı";
                    return View();
                }
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
	}
}