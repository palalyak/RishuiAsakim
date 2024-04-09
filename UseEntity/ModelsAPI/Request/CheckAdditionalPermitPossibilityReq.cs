using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Request
{
    public class CheckAdditionalPermitPossibilityReq
    {
        public int businessId { get; set; }
        public int additionalPermitType { get; set; }
    }

}
