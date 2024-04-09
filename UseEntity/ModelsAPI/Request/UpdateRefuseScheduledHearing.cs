using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Request
{
    public class UpdateRefuseScheduledHearing
    {
        public int id { get; set; }
        public string contactDateTime { get; set; }
        public int hearingCoordinationResultId { get; set; }
        public int secondPartyTypeId { get; set; }
        public string secondPartyName { get; set; }
        public int recorderUserId { get; set; }
    }

}
