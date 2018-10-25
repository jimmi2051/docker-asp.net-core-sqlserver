using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QL_Sach.Models;

namespace QL_Sach.Controllers
{
    public class BookController : Controller
    {
        private QL_SachContext db;
        public BookController(QL_SachContext _db)
        {
            db = _db;
        }
        public IActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBook(Book target)
        {
            try
            {
                db.Add(target);
                db.SaveChanges();
                return RedirectToAction("ViewBook");
               
            }
            catch
            {
                return View();
            }
        }
        public IActionResult EditBook(int ID)
        {
            Book target = db.Books.Where(c=>c.Id==ID).FirstOrDefault();
            if(target == null)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            else
            {
                return View(target);
            }
        }
        [HttpPost, ActionName("EditBook")]
        public IActionResult EditBook(Book target)
        {
            try
            {
                Book current = db.Books.Where(c=>c.Id == target.Id).FirstOrDefault();
                db.Entry(current).CurrentValues.SetValues(target);
                db.SaveChanges();
                return RedirectToAction("ViewBook");         
            }
            catch
            {
                return View(target.Id);
            }
        }
         public IActionResult DeleteBook(int ID)
        {
            Book target = db.Books.Where(c=>c.Id==ID).FirstOrDefault();
            if(target == null)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            else
            {
                return View(target);
            }
        }
// github.com/pqthang97/studentos
        [HttpPost, ActionName("DeleteBook")]
        public IActionResult DeleteConfirmed(int ID)
        {
            try
            {
                Book current = db.Books.Where(c=>c.Id==ID).FirstOrDefault();
                db.Books.Remove(current);
                db.SaveChanges();
                return RedirectToAction("ViewBook");         
            }
            catch
            {
                return View();
            }
        }
        public IActionResult ViewBook()
        {
            IEnumerable<Book> _result = db.Books.ToList();
            return View(_result);
        }
    }
}
