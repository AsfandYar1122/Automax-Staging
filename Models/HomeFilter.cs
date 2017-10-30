using Umbraco.Web.Models;
using Umbraco.Web;
using AutoMax.Models.DataModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AutomaxWebSite.Models
{
    public class HomeFilter
    {
        public SelectList MakerID { get; set; }
        public int MakeID { get; set; }

        public SelectList AutoModelID { get; set; }

        public int ModelId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string ModelName { get; set; }
    }
}