
using Umbraco.Web.Models;
using Umbraco.Web;
using AutoMax.Models.DataModel;
using System.Collections.Generic;
using System.Web.Mvc;
namespace AutomaxWebSite.Models
{
    public class Home:RenderModel
    {
        public Home() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent) { }
       
       public HomeFilter Filter { get; set; }
        
      
        public SelectList Name { get; set; }
       
        public SelectList ModelName { get; set; }

    }
}