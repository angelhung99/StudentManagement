using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index(string strSearch)
        {
            StudentList stulist = new StudentList();
            List<Student> obj = stulist.getStudent(string.Empty).OrderBy(x=>x.FullName).ToList();
            if (!String.IsNullOrEmpty(strSearch))
            {
                obj = obj.Where(x => x.FullName.Contains(strSearch) || x.Address.Contains(strSearch)).ToList();
            }
            ViewBag.StrSearch = strSearch;
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student stu)
        {
            if (ModelState.IsValid)
            {
                StudentList stulist = new StudentList();
                stulist.AddStudents(stu);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(string id = "")
        {
            StudentList stulist = new StudentList();
            List<Student> obj = stulist.getStudent(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]

        public ActionResult Edit(Student stu)
        {
            StudentList stulist = new StudentList();
            stulist.UpdateStudent(stu);
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id = "")
        {
            StudentList stulist = new StudentList();
            List<Student> obj = stulist.getStudent(id);
            return View(obj.FirstOrDefault());
        }
        public ActionResult Delete(string id = "")
        {
            StudentList stulist = new StudentList();
            List<Student> obj = stulist.getStudent(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(Student stu)
        {
            StudentList stulist = new StudentList();
            stulist.DeleteStudent(stu);
            return RedirectToAction("Index");
        }
    }
}