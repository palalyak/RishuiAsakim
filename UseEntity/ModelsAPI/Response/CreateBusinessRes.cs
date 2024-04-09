using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Response
{
    public class CreateBusinessRes
    {

        public class Rootobject
        {
            public Result[] results { get; set; }
            public int count { get; set; }
        }

        public class Result
        {
            public int id { get; set; }
            public string name { get; set; }
            public int updatedBy { get; set; }
            public string updatedUser { get; set; }
            public object description { get; set; }
            public object riskDegree { get; set; }
            public DateTime submissionDate { get; set; }
            public int submissionNumber { get; set; }
            public object submissionStatus { get; set; }
            public object submissionStatusDesc { get; set; }
            public string mainItem { get; set; }
            public int liceningNumber { get; set; }
            public object[] reasons { get; set; }
            //public Businessaddress[] businessAddress { get; set; }
            public Stakeholder[] stakeholders { get; set; }
            public object[] warnings { get; set; }
        }

        //public class Businessaddress
        //{
        //    public int id { get; set; }
        //    public int businessId { get; set; }
        //    public int addressType { get; set; }
        //    public object streetId { get; set; }
        //    public object streetDesc { get; set; }
        //    public object houseNumber { get; set; }
        //    public string entrance { get; set; }
        //    public object floor { get; set; }
        //    public object postalcode { get; set; }
        //    public object apartment { get; set; }
        //    public object mailBox { get; set; }
        //    public object block { get; set; }
        //    public object plot { get; set; }
        //    public int industrialSectionId { get; set; }
        //    public object industrialSectionDesc { get; set; }
        //    public object storeId { get; set; }
        //    public object neighborhoodId { get; set; }
        //    public object neighborhoodDesc { get; set; }
        //}

        public class Stakeholder
        {
            public string id { get; set; }
            public object idType { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public object companyName { get; set; }
            public int? cityId { get; set; }
            public int? street { get; set; }
            public int houseNumber { get; set; }
            public string enteranceNumber { get; set; }
            public string floorNumber { get; set; }
            public object deathDate { get; set; }
        }


    }
}
