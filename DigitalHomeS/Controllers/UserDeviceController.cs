using DigitalHomeS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DigitalHomeS.Services;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace DigitalHomeS.Controllers
   
{
    [System.Web.Mvc.Authorize]
    public class UserDeviceController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: UserDevice
       
        public async Task<ActionResult> Index()
        {


           
          // var User = db.Users.Include(p => p.Devices);
            var Devices =db.Devices.Include(p => p.Users);
           
            ViewBag.dev = Devices.ToList();
            return View(await Devices.ToListAsync());
        }
        public async Task<ActionResult> PartDev()
        {
            
        
            
           // var Device = db.Devices.Include(p => p.Users);
            var DevicesUser = db.Users.Include(p => p.Devices);
            return PartialView(await DevicesUser.ToListAsync());
        }
        [System.Web.Mvc.HttpGet]
        public async Task<ActionResult> ButtonZ(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            DeviceModels device =await db.Devices.FindAsync(id);
            if (device != null)
            {
                return View(device);
            }
            return HttpNotFound();
        }
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> ButtonZ(DeviceModels device)
        {
            db.Entry(device).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [System.Web.Mvc.HttpGet]
        public async Task<ActionResult> ButtonChange(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            DeviceModels device =await db.Devices.FindAsync(id);
            if (device != null)
            {
               
                device.last_activ_time = DateTime.Today.Date;
                device.last_activ_time+=DateTime.Now.TimeOfDay;
            var prodevice = device;
            if (prodevice.status == "1")
            {
                device.status = "0";
            }
            else {
                device.status ="1";
            }
            db.Entry(device).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
              
            }
            return HttpNotFound();

        }
    }
}