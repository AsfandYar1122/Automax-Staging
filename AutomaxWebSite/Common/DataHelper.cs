using AutoMax.Models;
using AutoMax.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AutomaxWebSite.Common
{
  
    public  class DataHelper
    {
        private AutoMax.Models.AutoMaxContext db = new AutoMax.Models.AutoMaxContext();

        public  SelectList GetMake()
        {
            
          return  new SelectList(db.Makers, "Name", GetDropDown("Name"), Name);
        }
        public SelectList GetModel()
        {

            return new SelectList(db.AutoModels, "ModelName", GetDropDown("ModelName"), ModelName);
        }
        public List<VehicleViewModel> GetFeatureVehicles()
        {
            InventoryRespository rep = new InventoryRespository();
            var data = rep.GetInventoryViewModelList(null, null, null, null, null, null,null,null,null,null,null, System.Globalization.CultureInfo.CurrentCulture.Name == "ar").Data as List<VehicleViewModel>;
            if (data != null)
            {
                data = data.Where(x => x.IsFeatured == true && x.InventoryStatus.ToLower()== "inventory").ToList();
                return data;
            }
            return null;
        }
        public SelectList GetVehiclesType()
        {
            int status = 1;
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.VehicleTypeID != null).Select(a => a.VehicleTypeID).Distinct().ToList();
            var lstResults = db.VehicleTypes.Where(a => lst.Contains(a.VehicleTypeID)).ToList();
            return new SelectList(lstResults, "VehicleTypeID", GetDropDown("Type"), Type);

        }
        public List<VehicleViewModel> GetHomeVehicles()
        {
            InventoryRespository rep = new InventoryRespository();
            var data= rep.GetInventoryStatusVM(System.Globalization.CultureInfo.CurrentCulture.Name == "ar").Data as List<VehicleViewModel>;
            if (data != null)
            {
              data = data.Where(x => x.IsFeatured != true).ToList();
            }
            
            return data;
        }
        public int Name { get; set; }
        public int ModelName { get; set; }
        public int Type { get; set; }

        public static  string GetDropDown(string value)
        {
            if (System.Globalization.CultureInfo.CurrentCulture.Name == "ar")
            {
                return "Arabic" + value;
            }
            else
            {
                return value;
            }
        }
    }
}