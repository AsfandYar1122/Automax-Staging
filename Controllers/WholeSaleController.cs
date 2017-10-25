
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
using AutomaxWebSite.Common;
using AutoMax.Models.Entities;

namespace AutomaxWebSite.Controllers
{
    public class WholeSaleController : RenderMvcController
    {
        private AutoMax.Models.AutoMaxContext db = new AutoMax.Models.AutoMaxContext();
        // GET: Contact
        public ActionResult Index(SearchFilter filter, int? VehicleTypeID, int? MakerId, int? AutoModelID, string Status, string Price, string MinYear, string MaxYear, string EngineName, string Transmission, string Title, string SortOrder, int? page)
        {
            try
            {
                var mod = new WebsiteInventory();
                var pageIndex = (page ?? 1); //MembershipProvider expects a 0 for the first page
                var pageSize = 10;
                var inv = "";
                InventoryRespository rep = new InventoryRespository();
                var data = new List<VehicleViewModel>(rep.GetInventoryStatusVMWholeSale(System.Globalization.CultureInfo.CurrentCulture.Name == "ar").Data as List<VehicleViewModel>);
                mod.Type = GetTypeList();
                List<SelectListItem> makerlist = new List<SelectListItem>();
                if (System.Globalization.CultureInfo.CurrentCulture.Name == "ar")
                {
                    makerlist.Insert(0, new SelectListItem { Value = "", Text = "حدد صانع" });
                }
                else
                {
                    makerlist.Insert(0, new SelectListItem { Value = "", Text = "Select Make" });
                }

                mod.Name = makerlist;
                if (VehicleTypeID != null)
                {
                    var allType = GetVehicleType(5);
                    var t = allType.Where(x => x.VehicleTypeID == VehicleTypeID).FirstOrDefault();
                    data = data.Where(x => x.VehicleType != null && (x.VehicleType == t.Type || x.VehicleType == t.ArabicType)).ToList();
                    mod.Name = GetMakersList(VehicleTypeID.Value);
                    filter.FilterExist = true;
                    inv += "&VehicleTypeID=" + VehicleTypeID;

                }

                if (MakerId != null)
                {
                    var m = GetMakers(5).Where(x => x.MakerID == MakerId).FirstOrDefault();
                    if (VehicleTypeID != 0)
                    {

                        data = data.Where(x => x.Maker != null && (x.Maker == m.Name || x.Maker == m.ArabicName)).ToList();
                        mod.Name = GetMakersList(VehicleTypeID.Value); //new SelectList(db.Makers.Where(x => x.VehicleTypeID == t.VehicleTypeID), DataHelper.GetDropDown("Name"), DataHelper.GetDropDown("Name"), mak.Name);
                        filter.FilterExist = true;//filter.FilterExist = true;
                        inv += "&MakerId=" + MakerId;
                    }

                }

                if (AutoModelID != null)
                {
                    var m = GetModels(5, VehicleTypeID.Value, MakerId.Value).Where(x => x.AutoModelID == AutoModelID).FirstOrDefault();
                    data = data.Where(x => x.AutoModelName != null && (x.AutoModelName == m.ModelName || x.AutoModelName == m.ArabicModelName)).ToList();
                    filter.FilterExist = true;
                    mod.ModelName = GetModelList(5, VehicleTypeID.Value, MakerId.Value);
                    inv += "&AutoModelID=" + AutoModelID.Value;
                    mod.AutoModelID = AutoModelID.Value;
                }
                else
                {
                    List<SelectListItem> list = new List<SelectListItem>();
                    if (System.Globalization.CultureInfo.CurrentCulture.Name == "ar")
                    {
                        list.Insert(0, new SelectListItem { Value = "", Text = "حدد موديل" });
                    }
                    else
                    {
                        list.Insert(0, new SelectListItem { Value = "", Text = "Select Model" });
                    }
                    mod.ModelName = list;
                }
                if (!string.IsNullOrEmpty(EngineName))
                {
                    data = data.Where(x => x.EngineName != null && x.EngineName == filter.EngineName).ToList();
                    filter.FilterExist = true;
                    mod.EngineName = new SelectList(db.AutoEngines, DataHelper.GetDropDown("EngineName"), DataHelper.GetDropDown("EngineName"), EngineName);
                    inv += "&EngineName=" + EngineName;
                }
                else
                {
                    mod.EngineName = new SelectList(db.AutoEngines, DataHelper.GetDropDown("EngineName"), DataHelper.GetDropDown("EngineName"), EngineName);
                }


                if (!string.IsNullOrEmpty(MinYear))
                {

                    data = data.Where(x => x.YearName != null && int.Parse(x.YearName) >= int.Parse(MinYear)).ToList();
                    filter.FilterExist = true;
                    inv += "&MinYear=" + MinYear;
                }
                if (!string.IsNullOrEmpty(MaxYear))
                {
                    data = data.Where(x => x.YearName != null && int.Parse(x.YearName) <= int.Parse(MaxYear)).ToList();
                    filter.FilterExist = true;
                }
                if (!string.IsNullOrEmpty(Transmission))
                {
                    data = data.Where(x => x.AutoTransmission != null && x.AutoTransmission == Transmission).ToList();
                    filter.FilterExist = true;
                    mod.Transmission = new SelectList(db.AutoTransmissions, "Transmission", DataHelper.GetDropDown("Transmission"), Transmission);
                    inv += "&Transmission=" + Transmission;
                }
                else
                {
                    mod.Transmission = new SelectList(db.AutoTransmissions, "Transmission", DataHelper.GetDropDown("Transmission"), Transmission);
                }
                if (!string.IsNullOrEmpty(Title))
                {
                    data = data.Where(x => x.VehicleTitle != null && x.VehicleTitle == Title).ToList();
                    filter.FilterExist = true;
                    inv += "&Title=" + Title;
                }
                if (!string.IsNullOrEmpty(Status) && Status != "Any")
                {
                    data = data.Where(x => x.AutoUsedStatus != null && x.AutoUsedStatus == filter.Status).ToList();
                    filter.FilterExist = true;
                    inv += "&Status=" + Status;
                }
                if (Status == "Any")
                {
                    filter.FilterExist = true;
                }
                if (!string.IsNullOrEmpty(Price))
                {
                    filter.Price = Price;
                    if (!Price.ToString().Contains("–"))
                    {
                        data = data.Where(x => x.VehiclePrice != null && float.Parse(x.VehiclePrice.ToString()) >= float.Parse(Price.ToString())).ToList();
                        filter.FilterExist = true;
                    }
                    else
                    {
                        var arr = Price.ToString().Split('–');
                        data = data.Where(x => x.VehiclePrice != null && (float.Parse(x.VehiclePrice.ToString()) >= float.Parse(arr[0].ToString()) && float.Parse(x.VehiclePrice.ToString()) <= float.Parse(arr[1].ToString()))).ToList();
                        filter.FilterExist = true;
                    }
                    inv += "&Price=" + Price;
                }
                if (!string.IsNullOrEmpty(SortOrder))
                {
                    if (SortOrder == "Price Low to High")
                    {
                        data = data.OrderBy(x => x.VehiclePrice).ToList();
                    }
                    else if (SortOrder == "High to Low")
                    {
                        data = data.OrderByDescending(x => x.VehiclePrice).ToList();
                    }
                    else if (SortOrder == "Name A - Z")
                    {
                        data = data.OrderBy(x => x.VehicleTitle).ToList();
                    }
                    else if (SortOrder == "Name A - Z")
                    {
                        data = data.OrderByDescending(x => x.VehicleTitle).ToList();
                    }
                    else if (SortOrder == "Newest First")
                    {
                        data = data.OrderBy(x => x.CreatedDate).ToList();
                    }
                    else if (SortOrder == "Newest First")
                    {
                        data = data.OrderByDescending(x => x.CreatedDate).ToList();
                    }
                    filter.FilterExist = true;
                    inv += "&SortOrder=" + SortOrder;
                }
                var t1 = (data.Count() / pageSize);
                int totalPages = (int)Math.Ceiling((double)data.Count() / 10);  // Math.Ceiling((decimal)(data.Count() / pageSize));
                int total = data.Count();
                mod.Filter = filter;
                mod.Make = new MakeOfferViewModel();
                mod.VehicleList = data.ToPagedList(pageIndex, pageSize);
                // mod.Name = new SelectList(db.Makers, "Name", "Name", Name);


                // mod.ModelName = new SelectList(db.AutoModels, "ModelName", "ModelName", ModelName);


                var root = Umbraco.TypedContentAtRoot().First();
                var vehiclePage = root.Children(x => x.DocumentTypeAlias == "vehicle").FirstOrDefault();
                mod.VehiclePageUrl = vehiclePage.Url;
                var url = root.GetPropertyValue<string>("applicationUrl").ToString();
                mod.Url = url;
                // int pageSize = 2;
                int pageNumber = (page ?? 1);
                //Used the following two formulas so that it doesn't round down on the returned integer

                ViewBag.TotalPages = totalPages;
                //These next two functions could maybe be reduced to one function....would require some testing and building
                //mod.VehicleList = new StaticPagedList<VehicleViewModel>(data, 1, pageSize, totalPages);
                ViewBag.inv = inv;
                ViewBag.total = total;
                ViewBag.PageNumber = pageNumber;

                return View("WholeSale", mod);
            }
            catch (Exception ex)
            {

                return View("ErrorPage");
            }

        }
        public List<SelectListItem> GetMakersList(int vehicleTypeId)
        {
            var res = GetMakers(1, vehicleTypeId);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in res)
            {
                list.Add(new SelectListItem { Value = item.MakerID.ToString(), Text = System.Globalization.CultureInfo.CurrentCulture.Name == "ar" ? item.ArabicName : item.Name });
            }
            if (System.Globalization.CultureInfo.CurrentCulture.Name == "ar")
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "حدد صانع" });
            }
            else
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Make" });
            }
            return list;
        }
        public List<Maker> GetMakers(int status)
        {
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.MakerID != null).Select(a => a.MakerID).Distinct().ToList();
            var lstResults = db.Makers.Where(a => lst.Contains(a.MakerID)).ToList();
            return lstResults;
        }
        public List<SelectListItem> GetTypeList()
        {
            var res = GetVehicleType(5);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in res)
            {
                list.Add(new SelectListItem { Value = item.VehicleTypeID.ToString(), Text = System.Globalization.CultureInfo.CurrentCulture.Name == "ar" ? item.ArabicType : item.Type });
            }
            if (System.Globalization.CultureInfo.CurrentCulture.Name == "ar")
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "اختر صنف" });
            }
            else
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Type" });
            }
            return list;
        }
        public List<VehicleType> GetVehicleType(int status)
        {
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.VehicleTypeID != null).Select(a => a.VehicleTypeID).Distinct().ToList();
            var lstResults = db.VehicleTypes.Where(a => lst.Contains(a.VehicleTypeID)).ToList();
            return lstResults;
        }
        public List<AutoModel> GetModels(int status)
        {
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.AutoModelID != null).Select(a => a.AutoModelID).Distinct().ToList();
            var lstResults = db.AutoModels.Where(a => lst.Contains(a.AutoModelID)).ToList();
            return lstResults;
        }
        public List<SelectListItem> GetModelList(int status, int VehicleTypeID, int MakerId)
        {
            var res = GetModels(status, VehicleTypeID, MakerId);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in res)
            {
                list.Add(new SelectListItem { Value = item.AutoModelID.ToString(), Text = System.Globalization.CultureInfo.CurrentCulture.Name == "ar" ? item.ArabicModelName : item.ModelName });
            }
            if (System.Globalization.CultureInfo.CurrentCulture.Name == "ar")
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "حدد موديل" });
            }
            else
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Model" });
            }
            return list;
        }
        public List<Maker> GetMakers(int status, int vehicleTypeId)
        {
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.MakerID != null && a.VehicleTypeID == vehicleTypeId ).Select(a => a.MakerID).Distinct().ToList();
            var lstResults = db.Makers.Where(a => lst.Contains(a.MakerID)).ToList();
            return lstResults;
        }
        public List<AutoModel> GetModels(int status, int vehicleTypeId, int makerId)
        {
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.AutoModelID != null && a.VehicleTypeID == vehicleTypeId && a.MakerID == makerId ).Select(a => a.AutoModelID).Distinct().ToList();
            var lstResults = db.AutoModels.Where(a => lst.Contains(a.AutoModelID)).ToList();
            return lstResults;
        }
    }
}