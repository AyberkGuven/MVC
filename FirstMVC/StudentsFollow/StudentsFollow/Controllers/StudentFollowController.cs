using StudentsFollow.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsFollow.Controllers
{
    public class StudentFollowController : Controller
    {
        //
        // GET: /StudentFollow/
        public ActionResult Index()
        {
            using (var db = new StudentFollowDbContext())
            {
                var data = (from s in db.StudentsFollowsStudents
                            join cl in db.StudentsFollowsclassRooms on s.Id equals cl.Id
                            select new
                            {
                                s.ImagePatch,
                                s.TC,
                                s.Name,
                                s.Surname,
                                Genders = s.Gender == false ? "Kadın" : "Erkek",
                                classRoom = cl.Name
                            }).ToList();

                return View(data);
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
	}
}