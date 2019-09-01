using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalHomeS.Models
{
    public class DeviceModels
    {
        public int Id { get; set; }
        public string macadress { get; set; }
        public string type_device { get; set; }
        public string status { get; set; }//Comand
        public DateTime last_activ_time { set; get; }
        public virtual ICollection<ApplicationUser> Users { get; set; }

        public DeviceModels()
        {
            Users = new List<ApplicationUser>();
        }
    }
}