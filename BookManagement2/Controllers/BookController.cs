using BookManagement2.DAL;
using BookManagement2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagement2.Controllers
{
    public class BookController : Controller
    {
        BookstoreDBEntities db = new BookstoreDBEntities();
        public ActionResult Index()
        {
            ViewBag.categoryID = new SelectList(db.Categories, "id", "category");
            return View();
        }
        public PartialViewResult RenderCategoryTable()
        {
            var model = db.Categories.ToList();
            return PartialView("~/Views/Book/_PartialCategoryTable.cshtml", model);
        }
        public PartialViewResult RenderBookTable()
        {
            var model = db.Books.ToList();
            return PartialView("~/Views/Book/_PartialBookTable.cshtml", model);
        }
        [HttpPost]
        public ActionResult CreateBook(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return Json(new { Success = true });
        }
    }
}