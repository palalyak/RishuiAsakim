using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Request
{
   
    public class CreateBusinessReq
    {
        public int id { get; set; }
        public string name { get; set; }
        public int path { get; set; }
        public int earlyInfoNum { get; set; }
        public int permitNum { get; set; }
        public int liceningNumber { get; set; }
        public int propertyTaxNum { get; set; }
        public bool highRisk { get; set; }
        public int expeditedPermitNum { get; set; }
        public int accompanyingPermitNum { get; set; }
        public bool buildingPreservation { get; set; }
        public bool dangerousBuilding { get; set; }
        public int commercialCenter { get; set; }
        public int pliceDistrictId { get; set; }
        public int accessType { get; set; }
        public int yardLocationType { get; set; }
        public string locationDescription { get; set; }
        public string comments { get; set; }
        public int propertyTaxAccountNum { get; set; }
        public int propertyTaxConstractNum { get; set; }
        public int buildingType { get; set; }
        public int cellArea { get; set; }
        public int areaSize_Reported { get; set; }
        public int parkingSpacesNum { get; set; }
        public int disabledParkingSpaces { get; set; }
        public int maxPeopleNumber { get; set; }
        public int roomsNumber { get; set; }
        public int seatsNumber { get; set; }
        public string phone { get; set; }
        public string phone2 { get; set; }
        public string email { get; set; }
        public int employeesNum { get; set; }
        public int primaryEssenceId { get; set; }
        public string businessDescription { get; set; }
        public int areaSizePargod { get; set; }
        public string grocerComment { get; set; }
        public int height { get; set; }
        public Licenserequest[] licenseRequests { get; set; }
        public Stakeholder[] stakeholders { get; set; }
        public Item[] items { get; set; }
       // public Businessaddress[] businessAddress { get; set; }
    }

    public class Licenserequest
    {
        public int id { get; set; }
        public int businessId { get; set; }
        public int requestNumber { get; set; }
        public int status { get; set; }
        public DateTime submissionDate { get; set; }
        public int submissionNumber { get; set; }
        public int submissionStatus { get; set; }
        public string submissionStatusDesc { get; set; }
        public string mainItem { get; set; }
        public bool isEditorRequired { get; set; }
        public bool isCanceled { get; set; }
        public string[] reasons { get; set; }
    }

    public class Stakeholder
    {
        public string name { get; set; }
        public int id { get; set; }
        public int stakeholderRequestId { get; set; }
        public string requestNumber { get; set; }
        public DateTime requestDate { get; set; }
        public int stakeholderType { get; set; }
        public string stakeholderTypeDesc { get; set; }
        public string email { get; set; }
        public int city { get; set; }
        public string cityDesc { get; set; }
        public int street { get; set; }
        public string streetDesc { get; set; }
        public int houseNumber { get; set; }
        public string phoneNumber1 { get; set; }
        public string phoneNumber2 { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public string number { get; set; }
        public string description { get; set; }
        public int accelerated { get; set; }
        public int seats { get; set; }
        public int statusId { get; set; }
    }

   // public class Businessaddress
    //{
    //    public int id { get; set; }
    //    public int businessId { get; set; }
    //    public int addressType { get; set; }
    //    public int streetId { get; set; }
    //    public string streetDesc { get; set; }
    //    public int houseNumber { get; set; }
    //    public string entrance { get; set; }
    //    public int floor { get; set; }
    //    public string postalcode { get; set; }
    //    public string apartment { get; set; }
    //    public string mailBox { get; set; }
    //    public int block { get; set; }
    //    public int plot { get; set; }
    //    public int industrialSectionId { get; set; }
    //    public string industrialSectionDesc { get; set; }
    //    public int storeId { get; set; }
    //    public int neighborhoodId { get; set; }
    //    public string neighborhoodDesc { get; set; }
    //}

}
