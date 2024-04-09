using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Request
{
    public class RenewAdditionalPermitReq
    {
        public int additionalPermitId { get; set; }
        public string requestEndHour { get; set; }
        public DateTime requestValidityStartDate { get; set; }
        public DateTime requestValidityEndDate { get; set; }
        public float requestPargodArea { get; set; }
    }

}
