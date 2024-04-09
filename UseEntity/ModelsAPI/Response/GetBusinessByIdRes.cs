using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Response
{


    public class GetBusinessByIdRes
    {
        public int? id { get; set; }
        public int? liceningNumber { get; set; }
        public string? name { get; set; }
        public string? propertyTaxAccountNum { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public int? requestNumber { get; set; }
        public int? yardLocationType { get; set; }
        public string? phone2 { get; set; }
        public string? businessTz { get; set; }
        public DateTime? openingDate { get; set; }
        public bool? isApprovedPlan { get; set; }
        public int? policeDistrictId { get; set; }
        public string? policeDistrictDesc { get; set; }
        public object identityNum { get; set; }
        public string? propertyTaxConstractNum { get; set; }
        public int? policeCaseNum { get; set; }
        public int? fireCertificateNumber { get; set; }
        public bool? isAtRisk { get; set; }
        public object closureOrder { get; set; }
        public object neighborhood { get; set; }
        public object block { get; set; }
        public object smooth { get; set; }
        public int? accessType { get; set; }
        public string? accessTypeDesc { get; set; }
        public int? industrialSectionId { get; set; }
        public string? industrialSectionDesc { get; set; }
        public float? areaSizeSales { get; set; }
        public float? areaSizePargod { get; set; }
        public float? areaSize { get; set; }
        public object buildingType { get; set; }
        public bool? dangerousBuilding { get; set; }
        public bool? preserveBuilding { get; set; }
        public bool? exceededUsage { get; set; }
        public object exceededUsageFinishDate { get; set; }
        public bool? isStreetConstruction { get; set; }
        public object address { get; set; }
        public object isFreeze { get; set; }
        public object freezeDate { get; set; }
        public object freezingType { get; set; }
        public object freezingTypeDesc { get; set; }
        public object freezeUser { get; set; }
        public object freezeUserName { get; set; }
        public object storageId { get; set; }
        public object storageNumber { get; set; }
        public object storageName { get; set; }
        public int? parkingSpacesNum { get; set; }
        public int? disabledParkingSpaces { get; set; }
        public float? tableSeatsSpace { get; set; }
        public int? maxPeopleNumber { get; set; }
        public int? roomsNumber { get; set; }
        public int? seatsNumber { get; set; }
        public int? employeesNum { get; set; }
        public object submitDeclarationDate { get; set; }
        public float? areaSize_Reported { get; set; }
        public float? areaSize_Measured { get; set; }
        public float? areaSize_ForTax { get; set; }
        public bool? isOpenSubmittion { get; set; }
        public Businessfile[] businessFiles { get; set; }
        public Affidavit[] affidavits { get; set; }
        public Notefile[] noteFiles { get; set; }
        //public Businessaddress[] businessAddress { get; set; }
        public Requestitem[] requestItems { get; set; }
        public Allbusinessrequestitem[] allBusinessRequestItems { get; set; }
        public object[] businessLicenses { get; set; }
        public Stakeholder[] stakeholders { get; set; }
        public Allstakeholder[] allStakeholders { get; set; }
        public Request[] requests { get; set; }
    }

    public class Businessfile
    {
        public int? id { get; set; }
        public int? businessId { get; set; }
        public int? requestid { get; set; }
        public object fileType { get; set; }
        public int? fileTypeId { get; set; }
        public int? formatType { get; set; }
        public string? url { get; set; }
        public object source { get; set; }
        public object sourceDesc { get; set; }
        public bool? onlineWatch { get; set; }
        public bool? isCanceled { get; set; }
        public int? cancelReason { get; set; }
        public string? cancelReasonDesc { get; set; }
        public object? cancelUser { get; set; }
        public int? uploadUser { get; set; }
        public int? approved { get; set; }
        public string? fileTypeDesc { get; set; }
        public object businessLicenseid { get; set; }
        public DateTime? createdDate { get; set; }
        public object contactId { get; set; }
        public object signDate { get; set; }
        public object signUser { get; set; }
        public object signUserDesc { get; set; }
        public bool? isActive { get; set; }
        public object refuseId { get; set; }
        public object[] sendDocument { get; set; }
    }

    public class Affidavit
    {
        public int? id { get; set; }
        public int? businessId { get; set; }
        public int? requestId { get; set; }
        public int? requestNumber { get; set; }
        public DateTime? createdDate { get; set; }
        public bool? isSubmitted { get; set; }
        public object submitedDepositionDate { get; set; }
        public int? reasonRejectingId { get; set; }
        public string? reasonRejectingDesc { get; set; }
        public object detailReasonRejecting { get; set; }
        public int? userUpdated { get; set; }
        public int? documentFileId { get; set; }
        public bool? status { get; set; }
        public string? url { get; set; }
    }

    public class Notefile
    {
        public int? id { get; set; }
        public int? businessId { get; set; }
        public int? noteCode { get; set; }
        public string noteDescription { get; set; }
        public DateTime creationDate { get; set; }
        public int userNote { get; set; }
        public object userName { get; set; }
        public bool isBlocker { get; set; }
        public object operationKey { get; set; }
    }

    //public class Businessaddress
    //{
    //    public int? id { get; set; }
    //    public int? businessId { get; set; }
    //    public int addressType { get; set; }
    //    public object streetId { get; set; }
    //    public int? houseNumber { get; set; }
    //    public string? entrance { get; set; }
    //    public int? floor { get; set; }
    //    public object postalcode { get; set; }
    //    public object apartment { get; set; }
    //    public object mailBox { get; set; }
    //    public float? block { get; set; }
    //    public float? smooth { get; set; }
    //    public object industrialSectionId { get; set; }
    //    public object storeId { get; set; }
    //}

    public class Requestitem
    {
        public int? itemNumber { get; set; }
        public int? requestItemId { get; set; }
        public string? name { get; set; }
        public int? pathId { get; set; }
        public string? pathDesc { get; set; }
        public object status { get; set; }
        public object statusDesc { get; set; }
        public float? area { get; set; }
        public int? crowdOccupancy { get; set; }
        public bool? isMainItem { get; set; }
        public Itemarea[] itemArea { get; set; }
        public object exceededUsageFinishDate { get; set; }
        public int[] requestIds { get; set; }
        public object isCanceled { get; set; }
    }

    public class Itemarea
    {
        public int? id { get; set; }
        public int? requestItemId { get; set; }
        public int? structureNumber { get; set; }
        public int? level { get; set; }
        public int? floor { get; set; }
        public float? areaHight { get; set; }
        public float? cellArea { get; set; }
        public int? cellAreaTarget { get; set; }
        public string? cellAreaTargetDesc { get; set; }
        public int? crowdOccupancy { get; set; }
    }

    public class Allbusinessrequestitem
    {
        public int? itemNumber { get; set; }
        public int? requestItemId { get; set; }
        public string? name { get; set; }
        public int? pathId { get; set; }
        public string? pathDesc { get; set; }
        public object status { get; set; }
        public object statusDesc { get; set; }
        public float? area { get; set; }
        public int? crowdOccupancy { get; set; }
        public bool? isMainItem { get; set; }
        public Itemarea1[] itemArea { get; set; }
        public object exceededUsageFinishDate { get; set; }
        public int[] requestIds { get; set; }
        public object isCanceled { get; set; }
    }

    public class Itemarea1
    {
        public int? id { get; set; }
        public int? requestItemId { get; set; }
        public int? structureNumber { get; set; }
        public int? level { get; set; }
        public int? floor { get; set; }
        public float? areaHight { get; set; }
        public float? cellArea { get; set; }
        public int? cellAreaTarget { get; set; }
        public string? cellAreaTargetDesc { get; set; }
        public int? crowdOccupancy { get; set; }
    }

    public class Stakeholder
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public int? stakeholderType { get; set; }
        public string? stakeholderTypeDesc { get; set; }
        public int? businessId { get; set; }
        public string? phoneNumber1 { get; set; }
        public string? phoneNumber2 { get; set; }
        public string? email { get; set; }
        public int? requestId { get; set; }
        public string? floorNumber { get; set; }
        public int? houseNumber { get; set; }
        public int? street { get; set; }
        public int? cityId { get; set; }
        public string? enteranceNumber { get; set; }
    }

    public class Allstakeholder
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public int? stakeholderType { get; set; }
        public string? stakeholderTypeDesc { get; set; }
        public int? businessId { get; set; }
        public string? phoneNumber1 { get; set; }
        public string? phoneNumber2 { get; set; }
        public string? email { get; set; }
        public int? requestId { get; set; }
        public string? floorNumber { get; set; }
        public int? houseNumber { get; set; }
        public int? street { get; set; }
        public int? cityId { get; set; }
        public string? enteranceNumber { get; set; }
    }

    public class Request
    {
        public int? id { get; set; }
        public int? businessId { get; set; }
        public int? requestNumber { get; set; }
        public int? status { get; set; }
        public string? statusDesc { get; set; }
        public object reason { get; set; }
        public string? reasonDesc { get; set; }
        public DateTime? submissionDate { get; set; }
        public int? submissionNumber { get; set; }
        public object isEditorRequired { get; set; }
        public DateTime? declarationDate { get; set; }
        public bool? feePaied { get; set; }
        public object payingDate { get; set; }
        public object isCanceled { get; set; }
        public Item[] items { get; set; }
        public object[] businessLicenses { get; set; }
        public Stakeholder1[] stakeholders { get; set; }
    }

    public class Item
    {
        public int? itemNumber { get; set; }
        public int? requestItemId { get; set; }
        public string? name { get; set; }
        public int? pathId { get; set; }
        public string pathDesc { get; set; }
        public object status { get; set; }
        public object statusDesc { get; set; }
        public float? area { get; set; }
        public int? crowdOccupancy { get; set; }
        public bool? isMainItem { get; set; }
        public Itemarea2[] itemArea { get; set; }
        public object exceededUsageFinishDate { get; set; }
        public int[] requestIds { get; set; }
        public object isCanceled { get; set; }
    }

    public class Itemarea2
    {
        public int? id { get; set; }
        public int? requestItemId { get; set; }
        public int? structureNumber { get; set; }
        public int? level { get; set; }
        public int? floor { get; set; }
        public float? areaHight { get; set; }
        public float? cellArea { get; set; }
        public int? cellAreaTarget { get; set; }
        public string? cellAreaTargetDesc { get; set; }
        public int? crowdOccupancy { get; set; }
    }

    public class Stakeholder1
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public int? stakeholderType { get; set; }
        public string? stakeholderTypeDesc { get; set; }
        public int? businessId { get; set; }
        public string? phoneNumber1 { get; set; }
        public string? phoneNumber2 { get; set; }
        public string? email { get; set; }
        public int? requestId { get; set; }
        public string? floorNumber { get; set; }
        public int? houseNumber { get; set; }
        public int? street { get; set; }
        public int? cityId { get; set; }
        public string? enteranceNumber { get; set; }
    }

}
