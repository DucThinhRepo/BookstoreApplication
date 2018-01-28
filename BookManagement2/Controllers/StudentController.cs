using BookManagement2.DAL;
using BookManagement2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagement2.Controllers
{
    public class StudentController : Controller
    {
        BookstoreDBEntities db = new BookstoreDBEntities();
        public ActionResult Index()
        {
            ViewBag.majorID = new SelectList(db.Majors, "id", "major");
            return View();
        }
        public PartialViewResult RenderTable()
        {
            return PartialView("~/Views/Student/_PartialTable.cshtml",db.Students.ToList());
        }
        
        [HttpPost]
        public ActionResult Create(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return Json(new { Success = true });
        }
        public JsonResult EditStudent(int id)
        {
            var data = db.Students.Find(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Student");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            db.Students.Remove(db.Students.Find(id));
            db.SaveChanges();
            return Json(new { Success = true });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}