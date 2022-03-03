using StudentsFollow.Context;
using StudentsFollow.Models;
using StudentsFollow.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
                var data = (from s in db.Students
                            join cl in db.Classrooms 
                            on s.ClassroomId equals cl.Id
                            select new StudentViewModel()
                            {
                                ImagePatch = s.ImagePatch,
                                Id = s.Id,
                                Name = s.Name,
                                Surname = s.Surname,
                                Genders = s.Gender == false ? "Kadın" : "Erkek",
                                ClassRoomId = cl.Name
                            }).ToList();

                return View(data);
            }
        }
        public ActionResult Create()
        {
            using (var db=new StudentFollowDbContext())
            {
                CreatDataViewModel data = new CreatDataViewModel();
                data.classRoomViewModels = db.Classrooms.Select(
                    cl=>new ClassRoomViewModel()
                    {
                        ClassRoomId=cl.Id,
                        Name=cl.Name
                    }).ToList();

                return View(data);
            }
        }
        [HttpPost]
        public ActionResult Create(CreatDataViewModel mgData,HttpPostedFileBase file)
        {
            string path = Path.Combine(Server.MapPath("~/Image"), Path.GetFileName(file.FileName));
            file.SaveAs(path);
            using (var db = new StudentFollowDbContext())
            {
                Student Students = new Student(){
                    Id = mgData.CreatStudentViewModels.Id,
                    Name = mgData.CreatStudentViewModels.Name,
                    Surname = mgData.CreatStudentViewModels.Surname,
                    Gender = mgData.CreatStudentViewModels.Genders,
                    ClassroomId = mgData.CreatStudentViewModels.ClassRoomId,
                    ImagePatch = Path.GetFileName(file.FileName)
                };
                db.Students.Add(Students);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Student mgData)
        {
            using (var db = new StudentFollowDbContext())
            {
                Student edit = new Student()
                {
                    Id = mgData.Id,
                    Name = mgData.Name,
                    Surname = mgData.Surname,
                    Gender = mgData.Gender,
                    ClassroomId = mgData.ClassroomId,
                    ImagePatch = mgData.ImagePatch
                };
            }
            return RedirectToAction("Edit");
        }
        public ActionResult Delete()
        {
            return View();
        }
	}
}