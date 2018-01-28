using BookManagement2.DAL;
using BookManagement2.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BookManagement2.Controllers
{
    public class LoginController : Controller
    {
        BookstoreDBEntities db = new BookstoreDBEntities();
        public ActionResult adminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adminLogin(Admin admin)
        {
            try
            {
                var acc = db.Admins.SingleOrDefault(a => a.username.Equals(admin.username));
                if (acc == null)
                {
                    ModelState.AddModelError("", "Invalid user name");
                }
                else
                {
                    if (acc.password.Equals(admin.password))
                    {
                        return RedirectToAction("Index", "Student");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid password");
                    }
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                throw;
            }
            return View();
        }

        public ActionResult studentLogin()
        {
            return View();
        }
        [HttpPost]
        [OutputCache(Duration = 3660, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult studentLogin(Student student)
        {
            try
            {
                var acc = db.Students.SingleOrDefault(a => a.username.Equals(student.username));
                if (acc == null)
                {
                    ModelState.AddModelError("", "Invalid user name");
                }
                else
                {
                    if (acc.password.Equals(student.password))
                    {
                        return RedirectToAction("Index", "Student");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid password");
                    }
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                throw;
            }
            return View();
        }
    }
}