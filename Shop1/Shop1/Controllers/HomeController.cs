using Shop1.Context;
using Shop1.ViewModel;
using System;
using System.Collections.Generic;
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
                                     MarkName = c.Name,
                                     NewProduct = p.NewProduct
                                 }).ToList();

                data.Category = db.Categorys.Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
                return View(data);
            }
        }
    }
}