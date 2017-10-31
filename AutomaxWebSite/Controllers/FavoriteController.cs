
using AutomaxWebSite.Models;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using AutoMax.Models;
using System.Collections.Generic;
using AutoMax.Models.DataModel;
using PagedList;
using System.Linq;
using Umbraco.Web;
using System;
using System.Web;

namespace AutomaxWebSite.Controllers
{
    public class FavoriteController : RenderMvcController
    {
        private AutoMax.Models.AutoMaxContext db = new AutoMax.Models.AutoMaxContext();
        // GET: Contact
        public ActionResult Index()
        {
            var root = Umbraco.TypedContentAtRoot().FirstOrDefault();
            var vehicleList = new List<VehicleViewModel>();
            Favorite model = new Favorite();
            try
            {
               
                var url = root.GetPropertyValue<string>("applicationUrl").ToString();
                HttpCookie myCookie = HttpContext.Request.Cookies["FavourietList"];
               
                if (myCookie != null && !string.IsNullOrEmpty(myCookie.Value))
                {
                    InventoryRespository rep = new InventoryRespository();
                    var arr = myCookie.Value.Split(',');
                    if (arr != null)
                    {
                        foreach (var item in arr)
                        {
                            var veh = rep.GetInventoryViewModelDetail(Convert.ToInt32(item), System.Globalization.CultureInfo.CurrentCulture.Name == "ar").Data as VehicleViewModel;
                            vehicleList.Add(veh);
                        }
                    }

                }
                model.Url = url;
                model.list = vehicleList;
               
            }
            catch (Exception ex)
            {

                var errorPage = root.Children(x => x.DocumentTypeAlias == "errorPage").FirstOrDefault();
                Response.Redirect(errorPage.Url);
            }
            return View(model);


        }
    }
}