
using Umbraco.Web.Models;
using Umbraco.Web;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using AutoMax;
using AutoMax.Models.Entities;
using System;

namespace AutomaxWebSite.Models
{
    public class Vehicle : RenderModel
    {
        public Vehicle() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent) { }
        public CarInformation Information { get; set; }
       
        public VirModel Vir { get; set; }
        public string VehicleImage { get; set; }
        public string InventoryPage { get; set; }
        public string Url { get; set; }
    }
    public class VirModel
    {
        public ExteriorModel Exterior { get; set; }
        public InteriorModel Interior { get; set; }
        public double Ratting { get; set; }
        public MechanicsModel Mechanics { get; set; }
        public FrameModel Frame { get; set; }
        public List<VIRFlagPropertiesViewModel> Flag { get; set; }
        public string FlagMoreOption { get; set; }
        public List<VIROptionsPropertiesViewModelGroupData> Otions { get; set; }
        public string MoreOption { get; set; }
       
        public List<VehicleAddressViewModel> Locations { get; set; }

    }
    public class ExteriorModel
    {
        public string Heading { get; set; }
        public string Part { get; set; }
        public string Condition { get; set; }
        public string ArabicCondition { get; set; }
        public double Ratting { get; set; }

        public int HeadlightId { get; set; }
        public PartsDataModel HeadlightData { get; set; }
        public int GrillId { get; set; }
        public PartsDataModel GrillData { get; set; }
        public int HoodId { get; set; }
        public PartsDataModel HoodData { get; set; }
        public int LeftFenderId { get; set; }
        public PartsDataModel LeftFenderData { get; set; }
        public int LinerLFRFId { get; set; }
        public PartsDataModel LinerLFRFData { get; set; }
        public int WindshieldId { get; set; }
        public PartsDataModel WindshieldData { get; set; }
        public int LFDoorId { get; set; }
        public PartsDataModel LFDoorData { get; set; }
        public int LRockerPanelId { get; set; }
        public PartsDataModel LRockerPanelData { get; set; }
        public int LRdoorId { get; set; }
        public PartsDataModel LRdoorData { get; set; }
        public int LeftQuarterPanelId { get; set; }
        public PartsDataModel LeftQuarterPanelData { get; set; }
        public int RearWindowId { get; set; }
        public PartsDataModel RearWindowData { get; set; }
        public int LeftBedSideId { get; set; }
        public PartsDataModel LeftBedSideData { get; set; }
        public int ConvertibleTopId { get; set; }
        public PartsDataModel ConvertibleTopData { get; set; }
        public int TrailGateId { get; set; }
        public PartsDataModel TrailGateData { get; set; }
        public int RightBedSideId { get; set; }
        public PartsDataModel RightBedSideData { get; set; }
        public int TailLightId { get; set; }
        public PartsDataModel TailLightData { get; set; }
        public int DeckLidId { get; set; }
        public PartsDataModel DeckLidData { get; set; }
        public int RightQuarterPanelId { get; set; }
        public PartsDataModel RightQuarterPanelData { get; set; }
        public int RRockerPanelId { get; set; }
        public PartsDataModel RRockerPanelData { get; set; }
        public int RRDoorId { get; set; }
        public PartsDataModel RRDoorData { get; set; }
        public int RoofId { get; set; }
        public PartsDataModel RoofData { get; set; }
        public int RFDoorId { get; set; }
        public PartsDataModel RFDoorData { get; set; }
        public int FrontBumperId { get; set; }
        public PartsDataModel FrontBumperData { get; set; }
        public int BumperGrillId { get; set; }
        public PartsDataModel BumperGrillData { get; set; }
        public int LMUDGuardId { get; set; }
        public PartsDataModel LMUDGuardData { get; set; }
        public int RightFenderId { get; set; }
        public PartsDataModel RightFenderData { get; set; }
        public int RMudGuardId { get; set; }
        public PartsDataModel RMudGuardData { get; set; }
        public int WIPERSId { get; set; }
        public PartsDataModel WIPERSData { get; set; }

        public int LeftMirrorId { get; set; }
        public PartsDataModel LeftMirrorData { get; set; }
        public int RightMirrorId { get; set; }
        public PartsDataModel RightMirrorData { get; set; }
        public int AnteenaId { get; set; }
        public PartsDataModel AnteenaData { get; set; }
        public int BackScreenId { get; set; }
        public PartsDataModel BackScreenData { get; set; }
        public int TRUNKCARGOId { get; set; }
        public PartsDataModel TRUNKCARGOData { get; set; }
        public int RREARLIGHTId { get; set; }
        public PartsDataModel RREARLIGHTData { get; set; }
        public int TAILERHITCHId { get; set; }
        public PartsDataModel TAILERHITCHData { get; set; }
        public int REARBUMPERId { get; set; }
        public PartsDataModel REARBUMPERData { get; set; }
        public int SunRoofID { get; set; }
        public PartsDataModel SunRoofData { get; set; }

        public int RightDoorID { get; set; }
        public PartsDataModel RightDoorData { get; set; }
        public int LeftDoorID { get; set; }
        public PartsDataModel LeftDoorData { get; set; }

    }
    public class InteriorModel
    {
        public string Heading { get; set; }
        public string Part { get; set; }
        public string Condition { get; set; }
        public double Ratting { get; set; }
        public int RearViewMirrorId { get; set; }
        public PartsDataModel RearViewMirrorData { get; set; }
        public int GaugesId { get; set; }
        public PartsDataModel GaugesData { get; set; }

        public int AirBagId { get; set; }
        public PartsDataModel AirBagData { get; set; }
        public int ShiftKnobId { get; set; }
        public PartsDataModel ShiftKnobData { get; set; }

        public int LFDoorPanelId { get; set; }
        public PartsDataModel LFDoorPanelData { get; set; }
        public int RHFRTSeatId { get; set; }
        public PartsDataModel RHFRTSeatData { get; set; }

        public int LHFRTSeatId { get; set; }
        public PartsDataModel LHFRTSeatData { get; set; }

        public int FrCarpetId { get; set; }
        public PartsDataModel FrCarpetData { get; set; }

        public int LRDoorPanelId { get; set; }
        public PartsDataModel LRDoorPanelData { get; set; }

        public int RRSeatsLeftId { get; set; }
        public PartsDataModel RRSeatsLeftData { get; set; }
        public int RRSeatsRightId { get; set; }
        public PartsDataModel RRSeatsRightData { get; set; }
        public int HeadLinerId { get; set; }
        public PartsDataModel HeadLinerData { get; set; }
        public int RFDoorPanelId { get; set; }
        public PartsDataModel RFDoorPanelData { get; set; }
        public int RRDoorPanelId { get; set; }
        public PartsDataModel RRDoorPanelData { get; set; }
        public int LampId { get; set; }
        public PartsDataModel LampData { get; set; }
        public int RadioId { get; set; }
        public PartsDataModel RadioData { get; set; }

        public int ConsoleId { get; set; }
        public PartsDataModel ConsoleData { get; set; }
        public int GloveBoxId { get; set; }
        public PartsDataModel GloveBoxData { get; set; }
        public int ThirdRowSeatId { get; set; }
        public PartsDataModel ThirdRowSeatData { get; set; }
        public int OdorId { get; set; }
        public PartsDataModel OdorData { get; set; }
        public int ManualsId { get; set; }
        public PartsDataModel ManualsData { get; set; }
        public int FeaturesId { get; set; }
        public PartsDataModel FeaturesData { get; set; }
        public int InteriorPartsId { get; set; }
        public PartsDataModel InteriorPartsData { get; set; }
        public int SteeringWheelId { get; set; }
        public PartsDataModel SteeringWheelData { get; set; }
        public int FourthRowSeatId { get; set; }
        public PartsDataModel FourthRowSeatData { get; set; }

        public int RearArmrestId { get; set; }
        public PartsDataModel RearArmrestData { get; set; }
        public int LRCarpetId { get; set; }
        public PartsDataModel LRCarpetData { get; set; }

        public int RRCarpetId { get; set; }
        public PartsDataModel RRCarpetData { get; set; }

        public int RrSeatsId { get; set; }
        public PartsDataModel RrSeatsData { get; set; }
        public int DashId { get; set; }
        public PartsDataModel DashData { get; set; }

    }
    public class MechanicsModel
    {
        public string Heading { get; set; }
        public string Part { get; set; }
        public string Condition { get; set; }
        public int PowerSteeringId { get; set; }
        public PartsDataModel PowerSteeringData { get; set; }
        public int ClimateControlId { get; set; }
        public PartsDataModel ClimateControlData { get; set; }
        public int FrontShockId { get; set; }
        public PartsDataModel FrontShockData { get; set; }
        public int FrontAxleId { get; set; }
        public PartsDataModel FrontAxleData { get; set; }
        public int LFWheelId { get; set; }
        public PartsDataModel LFWheelData { get; set; }
        public int TransmissionId { get; set; }
        public PartsDataModel TransmissionData { get; set; }
        public int BatteryId { get; set; }
        public PartsDataModel BatteryData { get; set; }
        public int RearShocksId { get; set; }
        public PartsDataModel RearShocksData { get; set; }
        public int RearAxleId { get; set; }
        public PartsDataModel RearAxleData { get; set; }
        public int LRWheelId { get; set; }
        public PartsDataModel LRWheelData { get; set; }
        public int ExhaustId { get; set; }
        public PartsDataModel ExhaustData { get; set; }
        public int LRWinMechanicsId { get; set; }
        public PartsDataModel LRWinMechanicsData { get; set; }
        public int LFWinMechanicsId { get; set; }
        public PartsDataModel LFWinMechanicsData { get; set; }
        public int LFDoorMechanicsId { get; set; }
        public PartsDataModel LFDoorMechanicsData { get; set; }
        public int LRDoorMechanicsId { get; set; }
        public PartsDataModel LRDoorMechanicsData { get; set; }
        public int RRDoorMechanicsId { get; set; }
        public PartsDataModel RRDoorMechanicsData { get; set; }
        public int RFDoorMechanicsId { get; set; }
        public PartsDataModel RFDoorMechanicsData { get; set; }
        public int RFWinMechanicsId { get; set; }
        public PartsDataModel RFWinMechanicsData { get; set; }
        public int RRWinMechanicsId { get; set; }
        public PartsDataModel RRWinMechanicsData { get; set; }
        public int EmissionId { get; set; }
        public PartsDataModel EmissionData { get; set; }
        public int RearBreakId { get; set; }
        public PartsDataModel RearBreakData { get; set; }
        public int RRWheelId { get; set; }
        public PartsDataModel RRWheelData { get; set; }
        public int ClutchId { get; set; }
        public PartsDataModel ClutchData { get; set; }
        public int FrontBreakId { get; set; }
        public PartsDataModel FrontBreakData { get; set; }
        public int RFWheelId { get; set; }
        public PartsDataModel RFWheelData { get; set; }
        public int EngineId { get; set; }
        public PartsDataModel EngineData { get; set; }
        public int ElectricsId { get; set; }
        public PartsDataModel ElectricsData { get; set; }
        public int SpareTypeId { get; set; }
        public PartsDataModel SpareTypeData { get; set; }
        public int FuelTankId { get; set; }
        public PartsDataModel FuelTankData { get; set; }
        public int WarningLightsId { get; set; }
        public PartsDataModel WarningLightsData { get; set; }
        public int ToolsJacksId { get; set; }
        public PartsDataModel ToolsJacksData { get; set; }
        public double Ratting { get; set; }
    }
    public class PartsDataModel
    {


        public PartsDataModel(double? ratting)
        {
            if (ratting != null && ratting != 0 && ratting != 0.0) {
                Ratting = Convert.ToDouble(ratting); }
            else { Ratting = 4; }
            
        }
        public PartsDataModel(dynamic data)
        {
            Condition = data.Condition;
            CostOfRepair = data.CostOfRepair;
            CostOfReplacement = data.CostOfReplacement;
            Description = data.Description;
            EstimatedRepairCost = data.EstimatedRepairCost;
            fkPartId = data.fkPartId;
            fkUserId = data.fkUserId;
            fkVehickeId = data.fkVehickeId;
            Part = data.Part;
            Id = data.Id;
            Ratting = data.Ratting;
            Severity = data.Severity;
            ImagePath = data.ImagePath;
            ArabicCondition = data.ArabicCondition;
        }

        public string ArabicCondition { get; set; }

        public int Id { get; set; }
        public int fkVehickeId { get; set; }
        public int fkUserId { get; set; }
        public int fkPartId { get; set; }
        public string Condition { get; set; }
        public string Part { get; set; }
        public double Severity { get; set; }
        public string Description { get; set; }
        public string CostOfRepair { get; set; }
        public string CostOfReplacement { get; set; }
        public string EstimatedRepairCost { get; set; }
        public double Ratting { get; set; }
        public string ImagePath { get; set; }

    }
    public class FrameModel
    {
        public string Heading { get; set; }
        public string Part { get; set; }
        public string Condition { get; set; }
        public double Ratting { get; set; }

        public int PerimeterFrameId { get; set; }
        public int RightRearRailId { get; set; }
        public int RadiatorCoreSupportId { get; set; }
        public int LeftFrontRailId { get; set; }
        public int LeftApronId { get; set; }
        public int LeftStrutTowerApronId { get; set; }
        public int CowlPanelFirewallId { get; set; }
        public int LeftAPillarId { get; set; }
        public int LeftBPillarId { get; set; }
        public int LeftCPillarId { get; set; }
        public int LeftDPillarId { get; set; }
        public int RightAPillarId { get; set; }
        public int RightBPillarId { get; set; }
        public int RightCPillarId { get; set; }
        public int RightDPillarId { get; set; }
        public int LeftRearRailId { get; set; }
        public int LeftRearLockPillarId { get; set; }
        public int RightRearLockPillarId { get; set; }
        public int RIGHTFRONTRAILId { get; set; }
        public int RightApronId { get; set; }
        public int RSTRUTTWRAPRId { get; set; }
        public int FloorPansId { get; set; }

        public PartsDataModel PerimeterFrameData { get; set; }
        public PartsDataModel RightRearRailData { get; set; }
        public PartsDataModel RadiatorCoreSupportData { get; set; }
        public PartsDataModel LeftFrontRailData { get; set; }
        public PartsDataModel LeftApronData { get; set; }
        public PartsDataModel LeftStrutTowerApronData { get; set; }
        public PartsDataModel CowlPanelFirewallData { get; set; }
        public PartsDataModel LeftAPillarData { get; set; }
        public PartsDataModel LeftBPillarData { get; set; }
        public PartsDataModel LeftCPillarData { get; set; }
        public PartsDataModel LeftDPillarData { get; set; }
        public PartsDataModel RightAPillarData { get; set; }
        public PartsDataModel RightBPillarData { get; set; }
        public PartsDataModel RightCPillarData { get; set; }
        public PartsDataModel RightDPillarData { get; set; }
        public PartsDataModel LeftRearRailData { get; set; }
        public PartsDataModel LeftRearLockPillarData { get; set; }
        public PartsDataModel RightRearLockPillarData { get; set; }
        public PartsDataModel RIGHTFRONTRAILData { get; set; }
        public PartsDataModel RightApronData { get; set; }
        public PartsDataModel RSTRUTTWRAPRData { get; set; }
        public PartsDataModel FloorPansData { get; set; }


    }
    public class CarInformation
    {
        public string AutoBodyStyleID { get; set; }

        public string AutoConditionID { get; set; }

        public string AutoDoorsID { get; set; }

        public string AutoEngineID { get; set; }

        public string AutoExteriorColorID { get; set; }

        public string AutoInteriorColorID { get; set; }

        public string AutoModelID { get; set; }

        public string AutoSteeringID { get; set; }

        public string AutoTransmissionID { get; set; }

        public string DriveTypeID { get; set; }

        public string FuelTypeID { get; set; }

        public string InventoryStatusID { get; set; }

        public string MakerID { get; set; }
        public string ModelID { get; set; }

        public string YearID { get; set; }

        public int AutoAirBagID { get; set; }

        public string EngineCapacityID { get; set; }
        public string VehicleWheelID { get; set; }
        public string WheelId { get; set; }
        public string VehicleAudioID { get; set; }

        public string VehicleInteriorTypeID { get; set; }

        public string VehicleTopStyleID { get; set; }

        public string Odometer { get; set; }
        public string VIN { get; set; }
        public string StockNumber { get; set; }
        public string FreeText { get; set; }

        public string Door { get; set; }
        public decimal Price { get; set; }
        public string FuelType { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleName { get; set; }
        public string Interior { get; set; }
        public string Exterior { get; set; }
        public string DriveType { get; set; }
        public string Transformation { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Wheel { get; set; }
        public string TopStyle { get; set; }
        public bool Has360 { get; set; }
        public double Rating { get; set; }
        public string RoofTypeName { get; set; }
        public string UpholsteryName { get; set; }
        public string AutoAirBag { get; set; }
        public string EngineName { get; set; }
    }

}