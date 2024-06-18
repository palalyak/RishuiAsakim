using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Request
{
    public class CreateApprovingStationReq
    {
        public int requestItemId { get; set; }
        public int stationType { get; set; }
        public int stationStatus { get; set; }
        public int? approvingStationId { get; set; }
        public int? additionalPermitRequestId { get; set; }
        public int? requestItemVisitReportId { get; set; }
        public int? businessVisitReportId { get; set; }
        public int? businessVisitId { get; set; }
    }

}
