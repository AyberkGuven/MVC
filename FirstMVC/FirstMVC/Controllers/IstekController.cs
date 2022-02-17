using FirstMVC.Context;
using FirstMVC.Models;
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
        //public ActionResult Update()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Mesaj mesaj)
        {
            DbMesaj db = new DbMesaj();
            db.Mesajs.Add(mesaj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            DbMesaj db = new DbMesaj();
            var mesaj = db.Mesajs.Find(id);
            return View(mesaj);
        }
        [HttpPost]
        public ActionResult Edit(Mesaj mesaj)
        {
            DbMesaj db = new DbMesaj();
            var data = db.Mesajs.Find(mesaj.Id);
            data.Name = mesaj.Name;
            data.Surname = mesaj.Surname;
            data.Phone = mesaj.Phone;
            data.Mail = mesaj.Mail;
            data.Request = mesaj.Request;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            DbMesaj db = new DbMesaj();
            var Del = db.Mesajs.Find(id);
            db.Mesajs.Remove(Del);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}