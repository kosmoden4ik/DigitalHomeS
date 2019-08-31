using DigitalHomeS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalHomeS.Controllers
{
    
    
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            return View(db.ContentPage);
        }
        [HttpGet]
        public ActionResult EditArtical(int? id)
        {
           
            if (id == null)
            {
                return HttpNotFound();
            }
            ContentPageModels Page = db.ContentPage.Find(id);
            if (Page != null)
            {
                return View(Page);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditArtical(ContentPageModels contentPage)
        {
            db.Entry(contentPage).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(ContentPageModels ccontentPage)
        {
            ccontentPage.date_article = DateTime.Today.Date;
            db.Entry(ccontentPage).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ContentPageModels b = db.ContentPage.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ContentPageModels b = db.ContentPage.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.ContentPage.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}