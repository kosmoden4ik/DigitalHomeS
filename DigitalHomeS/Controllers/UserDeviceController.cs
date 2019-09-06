using DigitalHomeS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalHomeS.Controllers
{

    public class UserDeviceController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        // GET: UserDevice
        [RequireHttps]
        public ActionResult Index()
        {

           var Users = db.Users.Include(p => p.Devices);
            var Devices = db.Devices.Include(p => p.Users);
            return View(Devices.ToList());
        }

    }
}