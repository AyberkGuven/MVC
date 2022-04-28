using Shop1.Context;
using Shop1.ViewModel;
using Shop1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            using (var db = new ShopDbContext())
            {
                var data = new DataViewModel();

                data.Products = (from p in db.Productss
                                 join c in db.Categorys
                                 on p.CategoryId equals c.Id
                                 join m in db.Marks
                                 on p.MarkId equals m.Id
                                 select new ProductsViewModel()
                                 {
                                     Id = p.Id,
                                     Name = p.Name,
                                     Price = p.Price,
                                     ImagePath = p.ImagePath,
                                     CategoryName = c.Name,
                                     MarkName = m.Name,
                                     NewProduct = p.NewProduct
                                 }).ToList();

                data.Category = db.Categorys.Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
                data.Mark = db.Marks.Select(c => new MarkViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
                return View(data);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            using (var db = new ShopDbContext())
            {
                CreateDataViewModel data = new CreateDataViewModel();
                data.Category = db.Categorys.Select(
                    cn => new CategoryViewModel()
                    {
                        Id = cn.Id,
                        Name = cn.Name
                    }).ToList();
                data.Mark = db.Marks.Select(
                    m => new MarkViewModel()
                    {
                        Id = m.Id,
                        Name = m.Name
                    }).ToList();
                return View(data);
            }
        }
        [HttpPost]
        public ActionResult Create(CreateDataViewModel mgData, HttpPostedFileBase file)
        {
            Guid g = Guid.NewGuid();
            string uniq = g.ToString("D");

            using (var db = new ShopDbContext())
            {
                Products Product1 = new Products();
                if (file != null && file.ContentLength > 0 || uniq.ToLower() == ".png" || uniq.ToLower() == ".jpg")
                {
                    string fileName = uniq + Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/images"), fileName);
                    file.SaveAs(path);
                    Product1.ImagePath = fileName;
                }
                Product1.Name = mgData.Product.Name;
                Product1.Price = mgData.Product.Price;
                Product1.CategoryId = mgData.Product.CategoryId;
                Product1.MarkId = mgData.Product.MarkId;
                Product1.NewProduct = mgData.Product.NewProduct;
                //ImagePatch = Path.GetFileName(file.FileName)
                db.Productss.Add(Product1);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new ShopDbContext())
            {
                //var product = db.Productss.Where(e => e.Id == id).FirstOrDefault();
                EditDataViewModel editV = new EditDataViewModel();
                editV.Edit = db.Productss.Where(e => e.Id == id).Select(e => new EditViewModel()
                {
                    ImagePath = e.ImagePath,
                    Id = e.Id,
                    Name = e.Name,
                    Price = e.Price,
                    CategoryId = e.CategoryId,
                    MarkId = e.MarkId,
                    NewProduct = e.NewProduct
                }).FirstOrDefault();

                editV.Category = db.Categorys.Select(
                    c => new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();

                editV.Mark = db.Marks.Select(
                    m => new MarkViewModel()
                    {
                        Id = m.Id,
                        Name = m.Name
                    }).ToList();

                return View(editV);
            }
        }
        [HttpPost]
        public ActionResult Edit(EditDataViewModel mgData, HttpPostedFileBase file, int id)
        {
            Guid g = Guid.NewGuid();
            string uniq = g.ToString("D");

            using (var db = new ShopDbContext())
            {
                var Edit = db.Productss.Find(mgData.Edit.Id);
                if (file != null && file.ContentLength > 0 || uniq.ToLower() == ".png" || uniq.ToLower() == ".jpg")
                {
                    string fileName = uniq + Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/images"), fileName);
                    file.SaveAs(path);
                    Edit.ImagePath = fileName;
                }
                Edit.Name = mgData.Edit.Name;
                Edit.Price = mgData.Edit.Price;
                Edit.CategoryId = mgData.Edit.CategoryId;
                Edit.MarkId = mgData.Edit.MarkId;
                Edit.NewProduct = mgData.Edit.NewProduct;
                //ImagePatch = Path.GetFileName(file.FileName)
                db.Productss.Add(Edit);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            using (var db = new ShopDbContext())
            {

                var product = db.Productss.Find(id);
                db.Productss.Remove(product);
                db.SaveChanges();

                var fullPatch = Server.MapPath("~/Image/" + product.ImagePath);

                if (System.IO.File.Exists(fullPatch))
                {
                    System.IO.File.Delete(fullPatch);
                }
                return RedirectToAction("Index");
            }

        }
    }
}