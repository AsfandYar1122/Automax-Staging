
using Umbraco.Web.Models;
using Umbraco.Web;
using AutoMax.Models.DataModel;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;

namespace AutomaxWebSite.Models
{
    public class Favorite : RenderModel
    {
        public Favorite() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent) { }
        public List<VehicleViewModel> list { get; set; }
        public string Url { get; set; }

    }
}