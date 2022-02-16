using FirstMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class IstekController : Controller
    {
        //
        // GET: /Istek/
        public ActionResult Index()
        {
            DbMesaj db = new DbMesaj();
            var request = db.Mesajs.ToList();
            return View(request);
        }
        public ActionResult Update()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
	}
}