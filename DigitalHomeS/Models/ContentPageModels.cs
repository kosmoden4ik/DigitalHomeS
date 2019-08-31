using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalHomeS.Models
{
    public class ContentPageModels
    {
        public int id { get; set; }
        public string content_article { get; set; }
        public string content_text { get; set; }
        public DateTime date_article { get; set; }
    }
}