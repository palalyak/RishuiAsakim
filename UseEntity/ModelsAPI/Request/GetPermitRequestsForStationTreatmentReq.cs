using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Request
{

    public class GetPermitRequestsForStationTreatmentReq
    {
        public int tab { get; set; }

        public DateTime? fromRequestDate { get; set; }

    }

}
