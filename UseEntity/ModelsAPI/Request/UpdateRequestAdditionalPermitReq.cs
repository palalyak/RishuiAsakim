using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Request
{
    public class UpdateRequestAdditionalPermitReq
    {
        public int additionalPermitRequestId { get; set; }
        public int statusId { get; set; }
    }

}
