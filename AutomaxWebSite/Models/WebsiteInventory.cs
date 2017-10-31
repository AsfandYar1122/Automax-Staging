
using Umbraco.Web.Models;
using Umbraco.Web;
using AutoMax.Models.DataModel;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;

namespace AutomaxWebSite.Models
{
    public class WebsiteInventory:RenderModel
    {
        public WebsiteInventory() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent) { }
        public SearchFilter Filter { get; set; }
        public IPagedList<VehicleViewModel> VehicleList { get; set; }
        public List<SelectListItem> Name { get; set; }
        public int MakerId { get; set; }
        public SelectList EngineName { get; set; }
       
        public int AutoModelID { get; set; }
        public List<SelectListItem> ModelName { get; set; }
        public MakeOfferViewModel Make { get; set; }

        public int VehicleTypeID { get; set; }
        public List<SelectListItem> Type { get; set; }
        public SelectList Transmission { get; set; }
        
        public string Url { get; set; }
        public string VehiclePageUrl { get; set; }


    }
}