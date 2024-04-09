using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Response
{
    public class GetPermitRequestsForStationTreatmentRes
    {
        public List<PermitRequest> PermitRequests { get; set; }
    }

    public class PermitRequest
    {
        public int businessId { get; set; }
        public bool inWorkProcess { get; set; }
        public string businessCaseNumber { get; set; }
        public string businessName { get; set; }
        public object mainEssence { get; set; }
        public int requestNumber { get; set; }
        public DateTime requestSubmissionDate { get; set; }
        public object requestReasons { get; set; }
        public int endTreatmentDaysAmount { get; set; }
        public string endTreatmentDaysAmountType { get; set; }
        public string additionalPermitType { get; set; }
        public int additionalPermitTypeId { get; set; }
        public object warnings { get; set; }
        public int stationTypeId { get; set; }
        public int approvingStationId { get; set; }
    }

}
