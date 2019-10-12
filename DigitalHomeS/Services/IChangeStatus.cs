using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHomeS.Controllers;
using DigitalHomeS.Models;
namespace DigitalHomeS.Services
{
   public interface IChangeStatus
    {
        void ChangeS(DeviceModels device);
    }
    public class ChangeStatuse : IChangeStatus
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void ChangeS(DeviceModels device)
        {
            string changerevers = device.status;
            if (changerevers == "1") changerevers = "0";
            changerevers = "1";
            device.status = changerevers;
            device.last_activ_time = DateTime.Today.Date; ;
            db.Entry(device).State = EntityState.Added;
            db.SaveChanges();
        }
    }
}
