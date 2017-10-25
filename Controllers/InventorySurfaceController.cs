
using AutomaxWebSite.Models;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using AutoMax.Models;
using System.Collections.Generic;
using AutoMax.Models.DataModel;
using System.Linq;
using PagedList;
using AutoMax.Models.Entities;
using System;
using System.Text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using SelectPdf;
using Umbraco.Core.Models;
using Umbraco.Web;
namespace AutomaxWebSite.Controllers
{
    public class InventorySurfaceController : SurfaceController
    {
        private AutoMax.Models.AutoMaxContext db = new AutoMax.Models.AutoMaxContext();
        // GET: Contact
       
      
        //public ActionResult Search(SearchFilter filter)
        //{
        //    var mod = new WebsiteInventory();
        //    var model = new SearchFilter();
        //    InventoryRespository rep = new InventoryRespository();
        //    mod.Filter = model;
        //    mod.VehicleList = (rep.GetInventoryViewModelList().Data as List<VehicleViewModel>).ToPagedList(1, 3);
        //    mod.Name = GetMakersList();//new SelectList(db.Makers, "MakerID", "Name", mod.Name);
        //    mod.EngineName = new SelectList(db.AutoEngines, "AutoEngineID", "EngineName", mod.EngineName);
          
        //    mod.ModelName = GetModelList();
        //    return View("/Views/Inventory.cshtml", mod);


        //}
        [HttpGet]
        public JsonResult LoadPargImages(long vehicleId)
        {
            try
            {


                var galleryObject = new VIRRepository().LoadVehicleImages(vehicleId, "VehicleAttachments/");
                  
                return Json(new { Success = true, data = galleryObject.Data }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "Error in Saving File. Try Again" }, JsonRequestBehavior.AllowGet));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactForm(Contact model)
        {
            try
            {
                MailMessage mm = new MailMessage();
                mm.To.Add(ConfigurationManager.AppSettings["ContactEmail"].ToString());
                mm.From = new MailAddress(ConfigurationManager.AppSettings["EmailFrom"]);
                mm.Subject = "Contact ";
                mm.IsBodyHtml = true;
                mm.Body = "Contact Us  Request:<br>" + "First Name: " + model.Name + "<br>Email: " + model.Email +
                          "<br><br>Subject:" + model.Subject + "<br>Message:" + model.Message;
                SmtpClient smtp = new SmtpClient { EnableSsl = false };
                smtp.Send(mm);
                return Json(new { success = true, Message = model }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            
           
        }
        [HttpGet]
        public void DownloadPdf(long vehicleid, string isArabic)
        {
            InventoryRespository rep = new InventoryRespository();
            var optonsList = new VIRRepository().LoadVIROptionProperties(vehicleid);
            var veh = rep.GetInventoryViewModelDetail(vehicleid, isArabic == "ar").Data as VehicleViewModel;
            string htmlString = "";
            var file = "";
            if (isArabic == "ar")
            {
                file = (System.Web.HttpContext.Current.Server.MapPath("~/") + "print_page_arabic.html");
               

            }
              else{
                file = (System.Web.HttpContext.Current.Server.MapPath("~/") + "print_page.html");
            }
            using (StreamReader sr1 = new StreamReader(file))
            {
                htmlString = sr1.ReadToEnd();
            }
            htmlString = htmlString.Replace("@name@", veh.VehicleTitle);
            htmlString = htmlString.Replace("@vir@", veh.TotalRatting!=null? String.Format("{0:0.00}", veh.TotalRatting):"4.0");
            htmlString = htmlString.Replace("@odometer@", !string.IsNullOrEmpty(veh.Odometer)?veh.Odometer:"N/A");
            htmlString = htmlString.Replace("@vin@", !string.IsNullOrEmpty(veh.VIN)?veh.VIN:"N/A");
            htmlString = htmlString.Replace("@engine@", !string.IsNullOrEmpty(veh.EngineName)?veh.EngineName:"N/A");

            htmlString = htmlString.Replace("@door@", !string.IsNullOrEmpty(veh.AutoDoor)?veh.AutoDoor:"N/A");
            htmlString = htmlString.Replace("@transformation@", !string.IsNullOrEmpty(veh.AutoTransmission)?veh.AutoTransmission:"N/A");
            htmlString = htmlString.Replace("@fueltype@", !string.IsNullOrEmpty(veh.FuelType)?veh.FuelType:"N/A");

            htmlString = htmlString.Replace("@stock@", !string.IsNullOrEmpty(veh.StockNumber)?veh.StockNumber:"N/A");
            htmlString = htmlString.Replace("@drivetype@", !string.IsNullOrEmpty(veh.DriveType)?veh.DriveType:"N/A");
            htmlString = htmlString.Replace("@interiorcolor@", !string.IsNullOrEmpty(veh.InteriorColor)?veh.InteriorColor:"N/A");

            htmlString = htmlString.Replace("@exteriorcolor@", !string.IsNullOrEmpty(veh.ExteriorColor)?veh.ExteriorColor:"N/A");
            var root = Umbraco.TypedContentAtRoot().First();
            var url = root.GetPropertyValue<string>("applicationUrl").ToString();
            if (!string.IsNullOrEmpty(veh.ImageName))
            {
               
                url = url + "VehicleAttachments/"+ veh.ImageName;
                var img = "<img style = 'width: auto; max-height: 100%;' src = '" + url+"'/>";
                
              
                htmlString = htmlString.Replace("@img1@", img);
            }
            else
            {
                htmlString = htmlString.Replace("@img1@", "&nbsp;");
            }
            if (!string.IsNullOrEmpty(veh.ImageName2))
            {
                url = "";
                url = url + "VehicleAttachments/" + veh.ImageName2;
                var img = "<img style = 'width: auto; max-height: 100%;' src = '" + url + "'/>";


                htmlString = htmlString.Replace("@img2@", img);
            }
            else
            {
                htmlString = htmlString.Replace("@img2@", "&nbsp;");
            }
            var html = "";
            List<VIROptionsPropertiesViewModelGroupData> Otions = optonsList.Data.List;
            foreach (var item in Otions.FirstOrDefault(a => a.Name == "Interior").List.Where(x=>x.Checked))
            {
                
                     html += "<li class='list-item'>"+ item.Name + "</li>";
                
               
            }
            foreach (var item in Otions.FirstOrDefault(a => a.Name == "Windows").List.Where(x => x.Checked))
            {

                html += "<li class='list-item'>" + item.Name + "</li>";


            }
            foreach (var item in Otions.FirstOrDefault(a => a.Name == "System").List.Where(x => x.Checked))
            {

                html += "<li class='list-item'>" + item.Name + "</li>";


            }
            foreach (var item in Otions.FirstOrDefault(a => a.Name == "Drive Train").List.Where(x => x.Checked))
            {

                html += "<li class='list-item'>" + item.Name + "</li>";


            }
            foreach (var item in Otions.FirstOrDefault(a => a.Name == "Safety").List.Where(x => x.Checked))
            {

                html += "<li class='list-item'>" + item.Name + "</li>";


            }
            foreach (var item in Otions.FirstOrDefault(a => a.Name == "Sound System").List.Where(x => x.Checked))
            {

                html += "<li class='list-item'>" + item.Name + "</li>";


            }
            foreach (var item in Otions.FirstOrDefault(a => a.Name == "Comfort").List.Where(x => x.Checked))
            {

                html += "<li class='list-item'>" + item.Name + "</li>";


            }
            foreach (var item in Otions.FirstOrDefault(a => a.Name == "Seats").List.Where(x => x.Checked))
            {

                html += "<li class='list-item'>" + item.Name + "</li>";


            }
            htmlString = htmlString.Replace(" @option@", html);
            string baseUrl = "";

            string pdf_page_size = "A4";
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pdf_page_size, true);

            string pdf_orientation = "Portrait";
            PdfPageOrientation pdfOrientation = (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), pdf_orientation, true);

            int webPageWidth = 1024;


            int webPageHeight = 0;

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

            // save pdf document
            doc.Save(HttpContext.ApplicationInstance.Response, false ,"Vehicle.pdf");

            // close pdf document
            doc.Close();
            
        }

        [HttpGet]
        public JsonResult LoadMaker(int vehicleTypeName,string isArabic,int status)
        {

            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.MakerID != null && a.VehicleTypeID == vehicleTypeName).Select(a => a.MakerID).Distinct().ToList();
            var lstResults = db.Makers.Where(a => lst.Contains(a.MakerID)).ToList();
            var data = from a in lstResults.Where(x => x.VehicleTypeID ==vehicleTypeName).OrderBy(x=>x.Name)
                       select new
                       {
                           Name= isArabic=="ar" ? a.ArabicName:a.Name,
                           Id= a.MakerID,
                       };
            return (Json(new { Success = true, data=data }, JsonRequestBehavior.AllowGet));

        }

        [HttpGet]
        public JsonResult LoadModel(int MakerName, string isArabic,int VehicleName,int status)
        {
            
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.AutoModelID != null && a.VehicleTypeID == VehicleName && a.MakerID == MakerName ).Select(a => a.AutoModelID).Distinct().ToList();
            var lstResults = db.AutoModels.Where(a => lst.Contains(a.AutoModelID)).ToList();
            var data = from a in lstResults.Where(x => x.MakerID == MakerName).OrderBy(x=>x.ModelName)
                       select new
                       {
                           Name = isArabic=="ar" ? a.ArabicModelName: a.ModelName,
                           Id = a.AutoModelID,
                       };
            return (Json(new { Success = true, data = data }, JsonRequestBehavior.AllowGet));

        }

        [HttpPost]
      public JsonResult SubscribeEmail(string email)
        {
            try
            {
                MailMessage mm = new MailMessage();
                mm.To.Add(ConfigurationManager.AppSettings["ContactEmail"].ToString());
                mm.From = new MailAddress(ConfigurationManager.AppSettings["EmailFrom"]);
                mm.Subject = "Subscribe";
                mm.IsBodyHtml = true;
                mm.Body = "Subscirbe Request:<br>" + "Email: " + email;
                          
                SmtpClient smtp = new SmtpClient { EnableSsl = false };
                smtp.Send(mm);
                return Json(new { Success = true, Message = email }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }


        }

        [HttpGet]
        public JsonResult AddFavorite(int Id, string isArabic)
        {
            HttpCookie myCookie = HttpContext.Request.Cookies["FavourietList"] ?? new HttpCookie("FavourietList");
            var message = isArabic == "ar" ? "هذه السيارة هي بالفعل في قائمة التجاهل" : "This Vehicle is already in Favorite List";
            if (myCookie!=null)
            {
                
                var value = myCookie.Value;
                if (value==null || value=="")
                {
                    myCookie.Value = Id.ToString();
                    message = isArabic == "ar"? "واضاف مركبة في قائمة التجاهل" : "Vehicle Added in Favorite List";
                    
                }
                else if (value.Contains(Id.ToString()))
                {
                    message = isArabic == "ar" ? "هذه السيارة هي بالفعل في قائمة التجاهل" : "This Vehicle is already in Favorite List";
                }
                else
                {
                    myCookie.Value += "," + Id;
                    message = isArabic == "ar" ? "واضاف مركبة في قائمة التجاهل" : "Vehicle Added in Favorite List";
                }
                
            }
            else
            {
                myCookie.Value = Id.ToString();
                message = isArabic == "ar" ? "واضاف مركبة في قائمة التجاهل" : "Vehicle Added in Favorite List";
            }
            myCookie.Expires = DateTime.Now.AddDays(365);
            HttpContext.Response.Cookies.Add(myCookie);
            return (Json(new { Success = true,Message= message}, JsonRequestBehavior.AllowGet));
        }
        [AllowAnonymous]
        [HttpGet]
        public void pdf()
        {
            string htmlString = "";
            var file = (System.Web.HttpContext.Current.Server.MapPath("~/") + "practice-hours.html");
            var html = "<TR VALIGN=TOP><TD WIDTH=75 STYLE='border-top: 3.00pt solid #6773b6; border-bottom: 3.00pt solid #6773b6; border-left: 3.00pt solid #6773b6; border-right: none; padding-top: 0in; padding-bottom: 0in; padding-left: 0.08in; padding-right: 0in'>"
            + "<P CLASS='western' STYLE='widows: 0; orphans: 0;padding-top:12px;'><FONT COLOR='#5162a5'><FONT FACE='Arial, sans-serif'><FONT SIZE=2><SPAN LANG='en-GB'><B>Dates:</B></SPAN></FONT></FONT></FONT></P></TD>" +
            "<TD WIDTH=115 STYLE='border-top: 3.00pt solid #6773b6; border-bottom: 3.00pt solid #6773b6; border-left: 3.00pt solid #6773b6; border-right: none; padding-top: 0in; padding-bottom: 0in; padding-left: 0.08in; padding-right: 0in'>" +
            "<P CLASS='western' STYLE='widows: 0; orphans: 0;padding-top:12px;'><FONT COLOR='#5162a5'><FONT FACE='Arial, sans-serif'><FONT SIZE=2><SPAN LANG='en-GB'><B>Name and address of <BR> organisation:</B></SPAN></FONT></FONT></FONT></P></TD>" +
             "<TD WIDTH=115 STYLE='border-top: 3.00pt solid #6773b6; border-bottom: 3.00pt solid #6773b6; border-left: 3.00pt solid #6773b6; border-right: none; padding-top: 0in; padding-bottom: 0in; padding-left: 0.08in; padding-right: 0in'>" +
            "<P CLASS='western' STYLE='widows: 0; orphans: 0;padding-top:12px;'><FONT COLOR='#5162a5'><FONT FACE='Arial, sans-serif'><FONT SIZE=2><SPAN LANG='en-GB'><B>Name and address of <BR> organisation:</B></SPAN></FONT></FONT></FONT></P></TD>" +
             "<TD WIDTH=115 STYLE='border-top: 3.00pt solid #6773b6; border-bottom: 3.00pt solid #6773b6; border-left: 3.00pt solid #6773b6; border-right: none; padding-top: 0in; padding-bottom: 0in; padding-left: 0.08in; padding-right: 0in'>" +
            "<P CLASS='western' STYLE='widows: 0; orphans: 0;padding-top:12px;'><FONT COLOR='#5162a5'><FONT FACE='Arial, sans-serif'><FONT SIZE=2><SPAN LANG='en-GB'><B>Name and address of <BR> organisation:</B></SPAN></FONT></FONT></FONT></P></TD>" +
             "<TD WIDTH=115 STYLE='border-top: 3.00pt solid #6773b6; border-bottom: 3.00pt solid #6773b6; border-left: 3.00pt solid #6773b6; border-right: none; padding-top: 0in; padding-bottom: 0in; padding-left: 0.08in; padding-right: 0in'>" +
            "<P CLASS='western' STYLE='widows: 0; orphans: 0;padding-top:12px;'><FONT COLOR='#5162a5'><FONT FACE='Arial, sans-serif'><FONT SIZE=2><SPAN LANG='en-GB'><B>Name and address of <BR> organisation:</B></SPAN></FONT></FONT></FONT></P></TD>" +
             "<TD WIDTH=115 STYLE='border-top: 3.00pt solid #6773b6; border-bottom: 3.00pt solid #6773b6; border-left: 3.00pt solid #6773b6; border-right: none; padding-top: 0in; padding-bottom: 0in; padding-left: 0.08in; padding-right: 0in'>" +
            "<P CLASS='western' STYLE='widows: 0; orphans: 0;padding-top:12px;'><FONT COLOR='#5162a5'><FONT FACE='Arial, sans-serif'><FONT SIZE=2><SPAN LANG='en-GB'><B>Name and address of <BR> organisation:</B></SPAN></FONT></FONT></FONT></P></TD>" +
             "<TD WIDTH=266 STYLE=border: 3.00pt solid #6773b6; padding-top: 0.08in; padding-bottom: 0.08in; padding-left: 0.08in; padding-right: 0.39in'><P CLASS='western' STYLE='margin-bottom: 0in; widows: 0; orphans: 0;padding-top:6px;'>" +
            "<FONT COLOR=\"#5162a5\"><FONT FACE=\"Arial, sans-serif\"><FONT SIZE=2><SPAN LANG=\"en-GB\"><B>Brief description of your work:</B></SPAN></FONT></FONT></FONT></P><P LANG=\"en-GB\" STYLE=\"margin-right: -0.34in; widows: 0; orphans: 0\">" +
            "<BR></P></TD></TR>";
            using (StreamReader sr1 = new StreamReader(file))
            {
                htmlString = sr1.ReadToEnd();
            }
            htmlString = htmlString.Replace("@practicehours@", html);
            string baseUrl = System.Web.HttpContext.Current.Server.MapPath("~/");

            string pdf_page_size = "A4";
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pdf_page_size, true);

            string pdf_orientation = "Portrait";
            PdfPageOrientation pdfOrientation = (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), pdf_orientation, true);

            int webPageWidth = 1024;


            int webPageHeight = 0;

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an url
            SelectPdf.PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

            // save pdf document
            //doc.Save("Vehicle.pdf");
            doc.Save(baseUrl + "Sample.pdf");
            // close pdf document
            doc.Close();


        }
        public List<Maker> GetMakers(int status,int vehicleTypeId)
        {
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.MakerID != null && a.VehicleTypeID == vehicleTypeId && a.IsDeleted != true).Select(a => a.MakerID).Distinct().ToList();
            var lstResults = db.Makers.Where(a => lst.Contains(a.MakerID)).ToList();
            return lstResults;
        }

        public List<AutoModel> GetModels(int status)
        {
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.AutoModelID != null).Select(a => a.AutoModelID).Distinct().ToList();
            var lstResults = db.AutoModels.Where(a => lst.Contains(a.AutoModelID)).ToList();
            return lstResults;
        }

        public ResultSetViewModel GetSubModels(int status)
        {
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.SubModelID != null).Select(a => a.SubModelID).Distinct().ToList();
            var lstResults = db.SubModels.Where(a => lst.Contains(a.SubModelID)).ToList();
            return new ResultSetViewModel(lstResults);
        }
        
        
        public List<SelectListItem> GetModelList()
        {
            var res = GetModels(1);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in res)
            {
                list.Add(new SelectListItem { Value = item.MakerID.ToString(), Text = item.ModelName });
            }
            list.Insert(0, new SelectListItem { Value = "", Text = "Select Model" });
            return list;
        }
    }
}