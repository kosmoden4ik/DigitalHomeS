using DigitalHomeS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
    namespace DigitalHomeS.Controllers
{
   
    public class ValuesController : ApiController
    {

 


          ApplicationDbContext db = new ApplicationDbContext();
          // GET api/<controller>
            [HttpGet]
        public IEnumerable<string> Get()
             {
            
                 return new string[] { "value1", "value2" };
             }

        // GET api/<controller>/5
       
        public string Get(string id)
          {
           //Find to mac
            if (id == null)
            {
                return "Error id is null";
            }
              List<DeviceModels> device =db.Devices.ToList();
            foreach (var x in device) {
                if (x.macadress == id)
                {
                    x.last_activ_time = DateTime.Today.Date;
                    x.status = "djeronimo";
                    x.type_device = "test";
                     db.Entry(x).State = EntityState.Modified;   
                }
            }
               // device.last_activ_time = DateTime.Today.Date;
               // device.status = "ok";
               // device.type_device = "test";
               // db.Entry(device).State = EntityState.Modified;
          
            db.SaveChanges();


                //end find
                string idd = id.ToString();
                string timing = DateTime.Today.ToShortTimeString();
                ContentPageModels ccontentPage = new ContentPageModels();
                ccontentPage.date_article = DateTime.Today.Date;
                ccontentPage.content_text = "Odio+" + idd;
                ccontentPage.content_article = "gvileske on web " + timing + " now";
                db.Entry(ccontentPage).State = EntityState.Added;
                db.SaveChanges();
                return "value";
            
           
          }
        
        [HttpPost]
        //  POST api/<controller>
        public void Post([FromBody]DeviceModels content)
        {

            string mac = content.macadress;
          /*  string timing = DateTime.Today.ToShortTimeString();
            ContentPageModels ccontentPage = new ContentPageModels();
            ccontentPage.date_article = DateTime.Today.Date;
            ccontentPage.content_text = "papi api+" + c;
            ccontentPage.content_article = "King " + timing + "!!!now";
            db.Entry(ccontentPage).State = EntityState.Added;
            db.SaveChanges();*/
            ///////////////////////////////////////////////
          
            List<DeviceModels> device = db.Devices.ToList();
            foreach (var x in device)
            {
                if (x.macadress == mac)
                {
                    x.last_activ_time = DateTime.Now;
                    x.status = content.status;
                    x.type_device = content.type_device;
                    db.Entry(x).State = EntityState.Modified;
                }
            }
                 db.SaveChanges();
        }
       
    


        /*    [HttpPost]
            //  POST api/<controller>
              public void Post([FromBody]ContentPageModels content)
              {
                  string c = content.content_article;
                string timing = DateTime.Today.ToShortTimeString();
                ContentPageModels ccontentPage = new ContentPageModels();
                ccontentPage.date_article = DateTime.Today.Date;
                ccontentPage.content_text = "papi api+" +c;
                ccontentPage.content_article = "King " + timing + "!!!now";
                db.Entry(ccontentPage).State = EntityState.Added;
                db.SaveChanges();

            }*/
        /*
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }*/
        
    }
}