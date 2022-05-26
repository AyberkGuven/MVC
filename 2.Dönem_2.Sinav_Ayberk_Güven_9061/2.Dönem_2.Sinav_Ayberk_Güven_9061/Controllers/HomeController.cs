using _2.Dönem_2.Sinav_Ayberk_Güven_9061.Context;
using _2.Dönem_2.Sinav_Ayberk_Güven_9061.Models;
using _2.Dönem_2.Sinav_Ayberk_Güven_9061.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2.Dönem_2.Sinav_Ayberk_Güven_9061.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            using (var db = new BootstrapShopDbContext())
            {
                var data = new DataViewModel();
                data.ProductViewModels = (from p in db.Products
                                          join c in db.Categorys
                                          on p.CategoryId equals c.Id
                                          select new ProductViewModel()
                                          {
                                              Id = p.Id,
                                              Name = p.Name,
                                              Price = p.Price,
                                              ImagePatch = p.ImagePatch,
                                              NewProduct = p.NewProduct,
                                              CategoryId = c.Id,
                                          }).ToList();
                data.CategoryViewModels = db.Categorys.Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
                data.ImageViewModel = db.Images.Select(i => new ImageViewModel()
                {
                    Id = i.Id,
                    ImageName = i.ImageName
                }).ToList();

                return View(data);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            using (var db = new BootstrapShopDbContext())
            {
                CreatDataViewModel data = new CreatDataViewModel();
                data.CategoryViewModels = db.Categorys.Select(
                    c => new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();
                return View(data);
            }
        }
        [HttpPost]
        public ActionResult Create(CreatDataViewModel mgData, HttpPostedFileBase file)
        {
            Guid g = Guid.NewGuid();
            string uniq = g.ToString("D");

            using (var db = new BootstrapShopDbContext())
            {
                Product product = new Product();
                if (file != null && file.ContentLength > 0 || uniq.ToLower() == ".png" || uniq.ToLower() == ".jpg")
                {
                    string fileName = uniq + Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("../themes/images/products/"), fileName);
                    file.SaveAs(path);
                    product.ImagePatch = fileName;
                }
                product.Name = mgData.CreatViewModels.Name;
                product.Price = mgData.CreatViewModels.Price;
                product.CategoryId = mgData.CreatViewModels.CategoryId;
                product.NewProduct = mgData.CreatViewModels.NewProduct;
                product.explanation = mgData.CreatViewModels.explanation;
                db.Products.Add(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            using (var db = new BootstrapShopDbContext())
            {
                EditDataViewModel editV = new EditDataViewModel();
                editV.EditViewModel = db.Products.Where(e => e.Id == id).Select(e => new EditViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    ImagePatch = e.ImagePatch,
                    NewProduct = e.NewProduct,
                    Price = e.Price,
                    CategoryId = e.CategoryId,
                    explanation = e.explanation
                }).FirstOrDefault();
                editV.CategoryViewModels = db.Categorys.Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
                return View(editV);
            }
        }
        [HttpPost]
        public ActionResult Detail(EditDataViewModel mgData, HttpPostedFileBase file, int id)
        {
            Guid g = Guid.NewGuid();
            string uniq = g.ToString("D");
            using (var db = new BootstrapShopDbContext())
            {
                var edit = db.Products.Find(id);
                edit.Name = mgData.EditViewModel.Name;
                edit.Price = mgData.EditViewModel.Price;
                edit.CategoryId = mgData.EditViewModel.CategoryId;
                edit.NewProduct = mgData.EditViewModel.NewProduct;
                edit.explanation = mgData.EditViewModel.explanation;
                if (file != null && file.ContentLength > 0 || uniq.ToLower() == ".png" || uniq.ToLower() == ".jpg")
                {
                    string fileName = uniq + Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/themes/images/products/"), fileName);
                    file.SaveAs(path);
                    edit.ImagePatch = fileName;
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            using (var db = new BootstrapShopDbContext())
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();

                var fullPatch = Server.MapPath("../themes/images/products/" + product.ImagePatch);

                if (System.IO.File.Exists(fullPatch))
                {
                    System.IO.File.Delete(fullPatch);
                }
                return RedirectToAction("Index");
            }
        }
    }
}