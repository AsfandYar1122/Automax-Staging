
using AutomaxWebSite.Models;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using AutoMax.Models;
using System.Collections.Generic;
using AutoMax.Models.DataModel;
using PagedList;
using System.Linq;
using AutoMax.Models.Entities;
using System;
using Umbraco.Web;
namespace AutomaxWebSite.Controllers
{
    public class MobileVehicleController : RenderMvcController
    {
        private AutoMax.Models.AutoMaxContext db = new AutoMax.Models.AutoMaxContext();
        // GET: Contact
        public ActionResult Index(int id)
        {
            var root = Umbraco.TypedContentAtRoot().FirstOrDefault();
            var errorPage = root.Children(x => x.DocumentTypeAlias == "errorPage").FirstOrDefault();
            
            Vehicle model = new Vehicle();
            try
            {

                
                VehicleWizard vehicleWizard = db.VehicleWizards.FirstOrDefault(d => d.VehicleID == id && (d.InventoryStatus.InventoryStatusID == 1 || d.InventoryStatus.InventoryStatusID == 5));
                if (vehicleWizard == null)
               {
              
                if (errorPage != null) Response.Redirect(errorPage.Url);
            }
            var exteriorData = new VIRRepository().GetVIR(id, VIRPartType.EXTERIOR);
            var interiorData = new VIRRepository().GetVIR(id, VIRPartType.INTERIOR);
            var mechanicsData = new VIRRepository().GetVIR(id, VIRPartType.MECHANICS);
            var frameData = new VIRRepository().GetVIR(id, VIRPartType.FRAME);
            
            var optonsList = new VIRRepository().LoadVIROptionProperties(id);
            var flagOptions = new VIRRepository().LoadVIRFlagProperties(id);
            InventoryRespository rep = new InventoryRespository();
           
            var v= rep.GetFeaturedInventoryViewModelById(id);
            var veh = rep.GetInventoryViewModelDetail(id, System.Globalization.CultureInfo.CurrentCulture.Name == "ar").Data as VehicleViewModel;
             var vehicleVideos = new VIRRepository().LoadVehicleVideos(id);
          
          
            var inventoryPage = root.Children(x => x.DocumentTypeAlias == "inventories").FirstOrDefault();
            if (inventoryPage != null) model.InventoryPage = inventoryPage.Url;
            model.Information = new CarInformation
            {
                AutoBodyStyleID = veh.VehicleTitle,
                AutoConditionID = veh.AutoUsedStatus,
                VehicleAudioID=veh.VehicleAudio,
                Door = veh.AutoDoor,
                AutoEngineID = veh.EngineName,
                AutoExteriorColorID = veh.ExteriorColor,
                AutoInteriorColorID = veh.InteriorColor,
                AutoModelID = veh.AutoModelName,
                AutoSteeringID = veh.AutoSteering,
                AutoTransmissionID = veh.AutoTransmission,
                DriveTypeID = veh.DriveType,
                FuelTypeID = veh.FuelType,
                InventoryStatusID = veh.InventoryStatus,
                MakerID = veh.Maker,
                YearID = veh.YearName,
                AutoAirBagID = veh.AutoAirBag ?? 0,
                EngineCapacityID = veh.EngineCapacity,
                VIN = veh.VIN,
                Odometer = veh.Odometer,
                StockNumber = veh.StockNumber,
                Price = Convert.ToDecimal(veh.VehiclePrice),
                VehicleMake = veh.Maker,
                VehicleName = veh.VehicleTitle,
                ModelID = veh.AutoModelName,
                DriveType = veh.DriveType,
                Description = veh.Description,
                Wheel = veh.AutoWheel,
                TopStyle = veh.TopStyle,
                Has360 = (veh.Has360 != null && veh.Has360 != false),
                RoofTypeName= veh.RoofTypeName,
                UpholsteryName = veh.UpholsteryName,
                EngineName = veh.EngineName
               
            };


            
            var obj = new VIRRepository().LoadVehicleImages(id, "VehicleAttachments/");
            ViewBag.Gallery = obj.Data;
               model.Vir = new VirModel
            {
                Exterior = new ExteriorModel
                {
                    FrontBumperId = exteriorData.Data.FrontBumperId,
                    FrontBumperData = exteriorData.Data.FrontBumperData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.FrontBumperData),
                    GrillId = exteriorData.Data.GrillId,
                    GrillData = exteriorData.Data.GrillData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.GrillData),
                    HeadlightId = exteriorData.Data.HeadLightId,
                    HeadlightData = exteriorData.Data.HeadLightData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.HeadLightData),
                    HoodId = exteriorData.Data.HoodId,
                    HoodData = exteriorData.Data.HoodData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.HoodData),
                    LeftFenderId = exteriorData.Data.LeftFenderId,
                    LeftFenderData = exteriorData.Data.LeftFenderData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.LeftFenderData),
                    RightBedSideId = exteriorData.Data.RightBedSideId,
                    RightBedSideData = exteriorData.Data.RightBedSideData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.RightBedSideData),
                    LMUDGuardId = exteriorData.Data.LMUDGUARDId,
                    LMUDGuardData = exteriorData.Data.LMUDGUARDData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.LMUDGUARDData),
                    RightFenderId = exteriorData.Data.RightFenderId,
                    RightFenderData = exteriorData.Data.RightFenderData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.RightFenderData),
                    RMudGuardId = exteriorData.Data.RMudGuardId,
                    RMudGuardData = exteriorData.Data.RMudGuardData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.RMudGuardData),
                    WIPERSId = exteriorData.Data.WIPERSId,
                    WIPERSData = exteriorData.Data.WIPERSData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.WIPERSData),
                    WindshieldId = exteriorData.Data.RMudGuardId,
                    WindshieldData = exteriorData.Data.WindshieldData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.WindshieldData),
                    LeftMirrorId = exteriorData.Data.RMudGuardId,
                    LeftMirrorData = exteriorData.Data.WindshieldData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.WindshieldData),
                    RightMirrorId = exteriorData.Data.RMudGuardId,
                    RightMirrorData = exteriorData.Data.RightMirrorData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.RightMirrorData),
                    LFDoorId = exteriorData.Data.LFDoorId,
                    LFDoorData = exteriorData.Data.LFDoorData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.LFDoorData),
                    RFDoorId = exteriorData.Data.RFDoorId,
                    RFDoorData = exteriorData.Data.RFDoorData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.RFDoorData),
                    LRockerPanelId = exteriorData.Data.LRockerPanelId,
                    LRockerPanelData = exteriorData.Data.LRockerPanelData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.LRockerPanelData),
                    RoofId = exteriorData.Data.RoofId,
                    RoofData = exteriorData.Data.RoofData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.RoofData),
                    RearWindowId = exteriorData.Data.LRockerPanelId,
                    RearWindowData = exteriorData.Data.RearWindowData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.RearWindowData),
                    RRockerPanelId = exteriorData.Data.LRockerPanelId,
                    RRockerPanelData = exteriorData.Data.RRockerPanelData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.RRockerPanelData),
                    LRdoorId = exteriorData.Data.LRockerPanelId,
                    LRdoorData = exteriorData.Data.LRdoorData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.LRdoorData),
                    RRDoorId = exteriorData.Data.RRDoorId,
                    RRDoorData = exteriorData.Data.RRDoorData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.RRDoorData),
                    AnteenaId = exteriorData.Data.AnteenaId,
                    AnteenaData = exteriorData.Data.AnteenaData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.AnteenaData),
                    BackScreenId = exteriorData.Data.BackScreenId,
                    BackScreenData = exteriorData.Data.BackScreenData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.BackScreenData),
                    LeftQuarterPanelId = exteriorData.Data.LeftQuarterPanelId,
                    LeftQuarterPanelData = exteriorData.Data.LeftQuarterPanelData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.LeftQuarterPanelData),
                    TRUNKCARGOId = exteriorData.Data.TRUNKCARGOId,
                    TRUNKCARGOData = exteriorData.Data.TRUNKCARGOData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.TRUNKCARGOData),
                    RightQuarterPanelId = exteriorData.Data.RightQuarterPanelId,
                    RightQuarterPanelData = exteriorData.Data.RightQuarterPanelData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.RightQuarterPanelData),
                    RREARLIGHTId = exteriorData.Data.RREARLIGHTId,
                    RREARLIGHTData = exteriorData.Data.RREARLIGHTData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.RREARLIGHTData),
                    TAILERHITCHId = exteriorData.Data.TAILERHITCHId,
                    TAILERHITCHData = exteriorData.Data.TAILERHITCHData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.TAILERHITCHData),
                    REARBUMPERId = exteriorData.Data.REARBUMPERId,
                    REARBUMPERData = exteriorData.Data.REARBUMPERData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.REARBUMPERData),
                    Ratting = Convert.ToDouble(exteriorData.Data.Ratting),
                    SunRoofID = exteriorData.Data.SunRoofId,
                    SunRoofData = exteriorData.Data.SunRoofData == null ? new PartsDataModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataModel(exteriorData.Data.SunRoofData),
                    RightDoorID = exteriorData.Data.RightDoorId,
                    RightDoorData = exteriorData.Data.RightDoorData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(exteriorData.Data.RightDoorData),
                    LeftDoorID = exteriorData.Data.LeftDoorId,
                    LeftDoorData = exteriorData.Data.LeftDoorData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(exteriorData.Data.LeftDoorData),

                },
                Interior = new InteriorModel
                {
                    RearViewMirrorId = interiorData.Data.RearViewMirrorId,
                    RearViewMirrorData = interiorData.Data.RearViewMirrorData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.RearViewMirrorData),
                    GaugesId = interiorData.Data.GaugesId,
                    GaugesData = interiorData.Data.GaugesData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.GaugesData),
                    AirBagId = interiorData.Data.AirBagId,
                    AirBagData = interiorData.Data.AirBagData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.AirBagData),
                    ShiftKnobId = interiorData.Data.ShiftKnobId,
                    ShiftKnobData = interiorData.Data.ShiftKnobData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.ShiftKnobData),
                    LFDoorPanelId = interiorData.Data.LFDoorPanelId,
                    LFDoorPanelData = interiorData.Data.LFDoorPanelData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.LFDoorPanelData),
                    RHFRTSeatId = interiorData.Data.RHFRTSeatId,
                    RHFRTSeatData = interiorData.Data.RHFRTSeatData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.RHFRTSeatData),
                    LHFRTSeatId = interiorData.Data.LHFRTSeatId,
                    LHFRTSeatData = interiorData.Data.LHFRTSeatData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.LHFRTSeatData),
                    FrCarpetId = interiorData.Data.LHFRTSeatId,
                    FrCarpetData = interiorData.Data.LHFRTSeatData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.LHFRTSeatData),
                    LRDoorPanelId = interiorData.Data.LRDoorPanelId,
                    LRDoorPanelData = interiorData.Data.LRDoorPanelData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.LRDoorPanelData),
                    RrSeatsId = interiorData.Data.RRSeatId,
                    RrSeatsData = interiorData.Data.RRSeatData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.RRSeatData),
                    HeadLinerId = interiorData.Data.HeadLinerId,
                    HeadLinerData = interiorData.Data.HeadLinerData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.HeadLinerData),
                    RRDoorPanelId = interiorData.Data.RRDoorPanelId,
                    RRDoorPanelData = interiorData.Data.RRDoorPanelData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.RRDoorPanelData),
                    LampId = interiorData.Data.LampId,
                    LampData = interiorData.Data.LampData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.LampData),
                    RFDoorPanelId = interiorData.Data.RFDoorPanelId,
                    RFDoorPanelData = interiorData.Data.RFDoorPanelData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.RFDoorPanelData),
                    RadioId = interiorData.Data.RadioId,
                    RadioData = interiorData.Data.RadioData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.RadioData),
                    ConsoleId = interiorData.Data.ConsoleId,
                    ConsoleData = interiorData.Data.ConsoleData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.ConsoleData),
                    GloveBoxId = interiorData.Data.GloveBoxId,
                    GloveBoxData = interiorData.Data.GloveBoxData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.GloveBoxData),
                    DashId = interiorData.Data.DashId,
                    DashData = interiorData.Data.DashData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.DashData),
                    ManualsId = interiorData.Data.ManualsId,
                    ManualsData = interiorData.Data.ManualsData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.ManualsData),
                    LRCarpetId = interiorData.Data.LRCarpetId,
                    LRCarpetData = interiorData.Data.LRCarpetData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.LRCarpetData),
                    InteriorPartsId = interiorData.Data.InteriorPartsId,
                    InteriorPartsData = interiorData.Data.InteriorPartsData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.InteriorPartsData),
                    FeaturesId = interiorData.Data.FeaturesId,
                    FeaturesData = interiorData.Data.FeaturesData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.FeaturesData),
                    FourthRowSeatId = interiorData.Data.FourthRowSeatId,
                    FourthRowSeatData = interiorData.Data.FourthRowSeatData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.FourthRowSeatData),
                    OdorId = interiorData.Data.OdorId,
                    OdorData = interiorData.Data.OdorData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.OdorData),
                    RearArmrestId = interiorData.Data.RearArmrestId,
                    RearArmrestData = interiorData.Data.RearArmrestData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.RearArmrestData),
                    RRCarpetId = interiorData.Data.RRCarpetId,
                    RRCarpetData = interiorData.Data.RRCarpetData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.RRCarpetData),
                    ThirdRowSeatId = interiorData.Data.ThirdRowSeatId,
                    ThirdRowSeatData = interiorData.Data.ThirdRowSeatData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.ThirdRowSeatData),
                    RRSeatsLeftId = interiorData.Data.RRSeatsLeftId,
                    RRSeatsLeftData = interiorData.Data.RRSeatsLeftData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.RRSeatsLeftData),
                    RRSeatsRightId = interiorData.Data.RRSeatsRightId,
                    RRSeatsRightData = interiorData.Data.RRSeatsRightData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.RRSeatsRightData),
                    SteeringWheelId = interiorData.Data.SteeringWheelId,
                    SteeringWheelData = interiorData.Data.SteeringWheelData == null ? new PartsDataModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataModel(interiorData.Data.SteeringWheelData),
                    Ratting = Convert.ToDouble(interiorData.Data.Ratting),
                },
                Mechanics = new MechanicsModel
                {
                    PowerSteeringId = mechanicsData.Data.PowerSteeringId,
                    PowerSteeringData = mechanicsData.Data.PowerSteeringData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.PowerSteeringData),
                    ClimateControlId = mechanicsData.Data.ClimateControlId,
                    ClimateControlData = mechanicsData.Data.ClimateControlData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.ClimateControlData),
                    FrontShockId = mechanicsData.Data.FrontShockId,
                    FrontShockData = mechanicsData.Data.FrontShockData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.FrontShockData),
                    FrontAxleId = mechanicsData.Data.FrontAxleId,
                    FrontAxleData = mechanicsData.Data.FrontAxleData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.FrontAxleData),
                    LFWheelId = mechanicsData.Data.LFWheelId,
                    LFWheelData = mechanicsData.Data.LFWheelData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.LFWheelData),
                    TransmissionId = mechanicsData.Data.TransmissionId,
                    TransmissionData = mechanicsData.Data.TransmissionData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.TransmissionData),
                    BatteryId = mechanicsData.Data.BatteryId,
                    BatteryData = mechanicsData.Data.BatteryData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.BatteryData),
                    RearShocksId = mechanicsData.Data.RearShocksId,
                    RearShocksData = mechanicsData.Data.RearShocksData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.RearShocksData),
                    RearAxleId = mechanicsData.Data.RearAxleId,
                    RearAxleData = mechanicsData.Data.RearAxleData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.RearAxleData),
                    LRWheelId = mechanicsData.Data.LRWheelId,
                    LRWheelData = mechanicsData.Data.LRWheelData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.LRWheelData),
                    ExhaustId = mechanicsData.Data.ExhaustId,
                    ExhaustData = mechanicsData.Data.ExhaustData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.ExhaustData),
                    LRWinMechanicsId = mechanicsData.Data.LRWinMechanicsId,
                    LRWinMechanicsData = mechanicsData.Data.LRWinMechanicsData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.LRWinMechanicsData),
                    LFWinMechanicsId = mechanicsData.Data.LFWinMechanicsId,
                    LFWinMechanicsData = mechanicsData.Data.LFWinMechanicsData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.LFWinMechanicsData),
                    LFDoorMechanicsId = mechanicsData.Data.LFDoorMechanicsId,
                    LFDoorMechanicsData = mechanicsData.Data.LFDoorMechanicsData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.LFDoorMechanicsData),
                    LRDoorMechanicsId = mechanicsData.Data.LRDoorMechanicsId,
                    LRDoorMechanicsData = mechanicsData.Data.LRDoorMechanicsData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.LRDoorMechanicsData),
                    RRDoorMechanicsId = mechanicsData.Data.RRDoorMechanicsId,
                    RRDoorMechanicsData = mechanicsData.Data.RRDoorMechanicsData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.RRDoorMechanicsData),
                    RFDoorMechanicsId = mechanicsData.Data.RFDoorMechanicsId,
                    RFDoorMechanicsData = mechanicsData.Data.RFDoorMechanicsData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.RFDoorMechanicsData),

                    RFWinMechanicsId = mechanicsData.Data.RFWinMechanicsId,
                    RFWinMechanicsData = mechanicsData.Data.RFWinMechanicsData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.RFWinMechanicsData),
                    RRWinMechanicsId = mechanicsData.Data.RRWinMechanicsId,
                    RRWinMechanicsData = mechanicsData.Data.RRWinMechanicsData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.RRWinMechanicsData),
                    EmissionId = mechanicsData.Data.EmissionId,
                    EmissionData = mechanicsData.Data.EmissionData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.EmissionData),
                    RearBreakId = mechanicsData.Data.RearBreakId,
                    RearBreakData = mechanicsData.Data.RearBreakData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.RearBreakData),
                    RRWheelId = mechanicsData.Data.RRWheelId,
                    RRWheelData = mechanicsData.Data.RRWheelData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.RRWheelData),
                    ClutchId = mechanicsData.Data.ClutchId,
                    ClutchData = mechanicsData.Data.ClutchData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.ClutchData),

                    FrontBreakId = mechanicsData.Data.FrontBreakId,
                    FrontBreakData = mechanicsData.Data.FrontBreakData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.FrontBreakData),
                    RFWheelId = mechanicsData.Data.RFWheelId,
                    RFWheelData = mechanicsData.Data.RFWheelData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.RFWheelData),
                    EngineId = mechanicsData.Data.EngineId,
                    EngineData = mechanicsData.Data.EngineData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.EngineData),
                    ElectricsId = mechanicsData.Data.ElectricsId,
                    ElectricsData = mechanicsData.Data.ElectricsData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.ElectricsData),
                    SpareTypeId = mechanicsData.Data.SpareTypeId,
                    SpareTypeData = mechanicsData.Data.SpareTypeData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.SpareTypeData),
                    FuelTankId = mechanicsData.Data.FuelTankId,
                    FuelTankData = mechanicsData.Data.FuelTankData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.FuelTankData),

                    WarningLightsId = mechanicsData.Data.WarningLightsId,
                    WarningLightsData = mechanicsData.Data.WarningLightsData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.WarningLightsData),
                    ToolsJacksId = mechanicsData.Data.ToolsJacksId,
                    ToolsJacksData = mechanicsData.Data.ToolsJacksData == null ? new PartsDataModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataModel(mechanicsData.Data.ToolsJacksData),
                    Ratting = Convert.ToDouble(mechanicsData.Data.Ratting),
                },
                Frame = new FrameModel
                {
                    Ratting = Convert.ToDouble(frameData.Data.Ratting),
                    CowlPanelFirewallData = frameData.Data.CowlPanelFirewallData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.CowlPanelFirewallData),
                    CowlPanelFirewallId = frameData.Data.CowlPanelFirewallId,
                    LeftAPillarData = frameData.Data.LeftAPillarData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.LeftAPillarData),
                    LeftAPillarId = frameData.Data.LeftAPillarId,
                    LeftApronData = frameData.Data.LeftApronData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.LeftApronData),
                    LeftApronId = frameData.Data.LeftApronId,
                    LeftBPillarData = frameData.Data.LeftBPillarData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.LeftBPillarData),
                    LeftBPillarId = frameData.Data.LeftBPillarId,
                    LeftCPillarData = frameData.Data.LeftCPillarData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.LeftCPillarData),
                    LeftCPillarId = frameData.Data.LeftCPillarId,
                    LeftDPillarData = frameData.Data.LeftDPillarData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.LeftDPillarData),
                    LeftDPillarId = frameData.Data.LeftDPillarId,
                    LeftFrontRailData = frameData.Data.LeftFrontRailData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.LeftFrontRailData),
                    LeftFrontRailId = frameData.Data.LeftFrontRailId,
                    LeftRearLockPillarData = frameData.Data.LeftRearLockPillarData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.LeftRearLockPillarData),
                    LeftRearLockPillarId = frameData.Data.LeftRearLockPillarId,
                    LeftRearRailData = frameData.Data.LeftRearRailData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.LeftRearRailData),
                    LeftRearRailId = frameData.Data.LeftRearRailId,
                    LeftStrutTowerApronData = frameData.Data.LeftStrutTowerApronData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.LeftStrutTowerApronData),
                    LeftStrutTowerApronId = frameData.Data.LeftStrutTowerApronId,
                    PerimeterFrameData = frameData.Data.PerimeterFrameData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.PerimeterFrameData),
                    PerimeterFrameId = frameData.Data.PerimeterFrameId,
                    RadiatorCoreSupportData = frameData.Data.RadiatorCoreSupportData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.RadiatorCoreSupportData),
                    RadiatorCoreSupportId = frameData.Data.RadiatorCoreSupportId,
                    RightAPillarData = frameData.Data.RightAPillarData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.RightAPillarData),
                    RightAPillarId = frameData.Data.RightAPillarId,
                    RightApronData = frameData.Data.RightApronData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.RightApronData),
                    RightApronId = frameData.Data.RightApronId,
                    RightBPillarData = frameData.Data.RightBPillarData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.RightBPillarData),
                    RightBPillarId = frameData.Data.RightBPillarId,
                    RightCPillarData = frameData.Data.RightCPillarData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.RightCPillarData),
                    RightCPillarId = frameData.Data.RightCPillarId,
                    RightDPillarData = frameData.Data.RightDPillarData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.RightDPillarData),
                    RightDPillarId = frameData.Data.RightDPillarId,
                    RIGHTFRONTRAILData = frameData.Data.RIGHTFRONTRAILData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.RIGHTFRONTRAILData),
                    RIGHTFRONTRAILId = frameData.Data.RIGHTFRONTRAILId,
                    RightRearLockPillarData = frameData.Data.RightRearLockPillarData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.RightRearLockPillarData),
                    RightRearLockPillarId = frameData.Data.RightRearLockPillarId,
                    RightRearRailData = frameData.Data.RightRearRailData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.RightRearRailData),
                    RightRearRailId = frameData.Data.RightRearRailId,
                    RSTRUTTWRAPRData = frameData.Data.RSTRUTTWRAPRData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.RSTRUTTWRAPRData),
                    RSTRUTTWRAPRId = frameData.Data.RSTRUTTWRAPRId,
                    FloorPansData = frameData.Data.FloorPansData == null ? new PartsDataModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataModel(frameData.Data.FloorPansData),
                    FloorPansId = frameData.Data.FloorPansId
                },
                Flag = flagOptions.Data.List,
                Otions = optonsList.Data.List,
                MoreOption = optonsList.Data.MoreOptions,
                FlagMoreOption = flagOptions.Data.MoreFlags,
                Locations = new VIRRepository().LoadVehicleAddress(id).Data,
                Ratting = Convert.ToDouble(exteriorData.Data.TotalRatting),
               



            };
            var url = root.GetPropertyValue<string>("applicationUrl").ToString();
            if (!string.IsNullOrEmpty(veh.ImageName))
            {

                if (veh.ImageName.StartsWith("http://"))
                {
                    model.VehicleImage = veh.ImageName;
                }
                else
                {
                    model.VehicleImage = url + "VehicleAttachments/" + veh.ImageName;
                }
               
               
            }
            else if (!string.IsNullOrEmpty(veh.ImageName2))
            {
                if (veh.ImageName2.StartsWith("http://"))
                {
                    model.VehicleImage =  veh.ImageName2;
                }
                else
                {
                    model.VehicleImage = url + "VehicleAttachments/" + veh.ImageName2;
                }

                   

            }
            else
            {
                model.VehicleImage = null;
            }
            model.Url = url;
            var galleryObject = new VIRRepository().LoadVehicleImages(id, "VehicleAttachments/");
            ViewBag.Gallery = galleryObject.Data;
            ViewBag.VideoGallery = vehicleVideos.Data;
           
            }
            catch (Exception ex)
            {
                
                if (errorPage != null) Response.Redirect(errorPage.Url);
            }
            return View(model);
        }
        public string Status(string v)
        {
            if (System.Globalization.CultureInfo.CurrentCulture.Name == "ar")
            {
                if (v == "Used")
                {
                    return "مستخدم";
                }
                else
                {
                    return "الجديد";
                }
            }
            return v;
        }
    }
}