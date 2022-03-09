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
            string FileName = mgData.CreatStudentViewModels.Id + Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Image"),FileName);
            file.SaveAs(path);
            using (var db = new StudentFollowDbContext())
            {
                Student Students = new Student(){
                    Id = mgData.CreatStudentViewModels.Id,
                    Name = mgData.CreatStudentViewModels.Name,
                    Surname = mgData.CreatStudentViewModels.Surname,
                    Gender = mgData.CreatStudentViewModels.Genders,
                    ClassroomId = mgData.CreatStudentViewModels.ClassRoomId,
                    ImagePatch = FileName
                    //ImagePatch = Path.GetFileName(file.FileName)
                };
                db.Students.Add(Students);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            using (var db = new StudentFollowDbContext())
            {
                var student = db.Students.Where(s => s.Id == id).FirstOrDefault();
                EditDataViewModel edit = new EditDataViewModel();
                edit.EditStudentViewModel = db.Students.Where(s => s.Id == id).Select(s => new EditStudentViewModel(){
                    Id = s.Id,
                    Name = s.Name,
                    Surname = s.Surname,
                    Gender = s.Gender,
                    ClassRoomId = s.ClassroomId,
                    ImagePatch = s.ImagePatch
                }).FirstOrDefault();

                edit.ClassRoomViewModel = db.Classrooms.Select(
                    cl=>new ClassRoomViewModel()
                    {
                        ClassRoomId=cl.Id,
                        Name=cl.Name
                    }).ToList();

                return View(edit);
            }
        }
        [HttpPost]
        public ActionResult Edit(EditDataViewModel mgData, HttpPostedFileBase file)
        {
            
            using (var db = new StudentFollowDbContext())
            {

                    var student = db.Students.Find(mgData.EditStudentViewModel.Id);
                    student.Name = mgData.EditStudentViewModel.Name;
                    student.Surname = mgData.EditStudentViewModel.Surname;
                    student.Gender = mgData.EditStudentViewModel.Gender;
                    student.ClassroomId = mgData.EditStudentViewModel.ClassRoomId;
                    if (file != null && file.ContentLength > 0)
                    {
                        string FileName = mgData.EditStudentViewModel.Id + Path.GetExtension(file.FileName);
                        string path = Path.Combine(Server.MapPath("~/Image"), FileName);
                        file.SaveAs(path);
                        student.ImagePatch = file.FileName;
                        }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            using (var db = new StudentFollowDbContext())
            {
                
                var student = db.Students.Find(id);
                db.Students.Remove(student);
                db.SaveChanges();
                
                var fullPatch = Server.MapPath("~/Image/" + student.ImagePatch);

                if (System.IO.File.Exists(fullPatch))
                {
                    System.IO.File.Delete(fullPatch);
                }
                return RedirectToAction("Index");
            }

        }
	}
}