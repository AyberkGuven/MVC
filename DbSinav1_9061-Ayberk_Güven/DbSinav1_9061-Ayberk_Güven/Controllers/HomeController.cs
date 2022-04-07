using DbSinav1_9061_Ayberk_Güven.Context;
using DbSinav1_9061_Ayberk_Güven.ViewModel;
using DbSinav1_9061_Ayberk_Güven.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbSinav1_9061_Ayberk_Güven.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Products()
        {
            using (var db = new SinavDbContext())
            {
                var data = (from s in db.Productss
                            join cl in db.Detailss
                            on s.DetailsId equals cl.Id
                            select new ProductsViewModel()
                            {
                                Image = s.Image,
                                Id = s.Id,
                                Name = s.Name,
                                Price = s.Price,
                            }).ToList();

                return View(data);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new SinavDbContext())
            {
                var data = (from p in db.Productss
                            join d in db.Detailss
                             on p.DetailsId equals d.Id
                            where p.Id == id
                            select new DetailsViewModel()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Price = p.Price,
                                Image = p.Image,
                                Direction = p.Direction,
                                Genders = d.Genders,
                                DetailsId = d.Id,
                                Delete=false
                            }).FirstOrDefault();
                return View(data);
            }
        }
        [HttpPost]
        public ActionResult Edit(DetailsViewModel mgData, HttpPostedFileBase file, int id) 
        {
            
            using (var db = new SinavDbContext())
            {
                if (mgData.Delete)
                {
                    //Silme işlemi
                    var Products = db.Productss.Find(id);
                    db.Productss.Remove(Products);
                    db.SaveChanges();

                    var fullPatch = Server.MapPath("~/images/" + Products.Image);

                    if (System.IO.File.Exists(fullPatch))
                    {
                        System.IO.File.Delete(fullPatch);
                    }
                }
                else
                {
                    //Uniq dosya ismi üretildi
                    Guid g = Guid.NewGuid();
                    string uniq = g.ToString("D");

                    //update işlemi
                    var Products = db.Productss.Find(mgData.Id);
                    Products.Name = mgData.Name;
                    Products.Direction = mgData.Direction;
                    Products.DetailsId = mgData.DetailsId;
                    Products.Price = mgData.Price;
                    if (file != null && file.ContentLength > 0 || uniq.ToLower() == ".png" || uniq.ToLower() == ".jpg")
                    {
                        string fileName = uniq + Path.GetExtension(file.FileName);
                        string path = Path.Combine(Server.MapPath("~/images"), fileName);
                        file.SaveAs(path);
                        Products.Image = fileName;
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("Products");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DetailsViewModel mgData, HttpPostedFileBase file) 
        {
            Guid g = Guid.NewGuid();
            string uniq = g.ToString("D");
            
            using (var db = new SinavDbContext())
            {
                Products newData = new Products();
                newData.Name = mgData.Name;
                newData.Price = mgData.Price;
                newData.Direction = mgData.Direction;
                if (uniq.ToLower() == ".png" || uniq.ToLower() == ".jpg")
                {
                    string fileName = uniq + Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/images"), fileName);
                    file.SaveAs(path);
                    newData.Image = fileName;
                }
                newData.DetailsId = mgData.DetailsId;
                db.Productss.Add(newData);
                db.SaveChanges();
            }
            return RedirectToAction("Products");
        }
    }
}