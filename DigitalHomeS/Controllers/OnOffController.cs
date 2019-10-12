using DigitalHomeS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DigitalHomeS.Controllers
{
    public class OnOffController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public async Task<int> Post([FromBody]DeviceModels content)
        {
            int vkl=333;
            string mac = content.macadress;

            List<DeviceModels> device =await db.Devices.ToListAsync();
            foreach (var x in device)
            {
                if (x.macadress == mac)
                {
                   

                    x.last_activ_time = DateTime.Now;
                   vkl=Convert.ToInt32(x.status);
                    x.type_device = "OnOff";
                    db.Entry(x).State = EntityState.Modified; 
                }
                
            }
           await db.SaveChangesAsync();
            return vkl;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}