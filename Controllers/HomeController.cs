using DbSinav1_9061_Ayberk_Güven.Context;
using DbSinav1_9061_Ayberk_Güven.ViewModel;
using System;
using System.Collections.Generic;
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
        public ActionResult Edit(int id)
        {
            using (var db = new SinavDbContext())
            {
                var Products = db.Productss.Where(s => s.Id == id).FirstOrDefault();
                CreatDataViewModel edit = new CreatDataViewModel();
                edit.DetailsViewModel = db.Productss.Where(s => s.Id == id).Select(s => new DetailsViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                    Direction = s.Direction,
                    Image = s.Image,
                    Genders = s.DetailsId == 1 ? "Erkek": "Kadın"
                }).FirstOrDefault();

                // 1 men's shirt 12 asdsd p.png 2
                
                return View(edit);
            }
        }
	}
}