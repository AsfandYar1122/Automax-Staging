
using Umbraco.Web.Models;
using Umbraco.Web;
using AutoMax.Models.DataModel;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
namespace AutomaxWebSite.Models
{
    public class Inventory:RenderModel
    {
        public Inventory() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent) { }
        
        public SearchFilter Filter { get; set; }
        public IPagedList<VehicleViewModel> VehicleList { get; set; }
        public SelectList Name { get; set; }
        public SelectList EngineName { get; set; }
        public SelectList Status { get; set; }
        public SelectList ModelName { get; set; }
        public MakeOfferViewModel Make { get; set; }
        public SelectList Type { get; set; }

    }
}