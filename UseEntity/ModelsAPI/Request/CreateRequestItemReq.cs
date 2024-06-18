using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Request
{
    public class CreateRequestItemReq
    {
        public int requestId { get; set; }
        public int businessId { get; set; }
        public int itemId { get; set; }
        public int pathId { get; set; }
        public bool isMainItem { get; set; }
        public bool newProgramRequired { get; set; }
        public bool isAddingDone { get; set; }
        public Areaslot[] areaSlots { get; set; }
    }

    public class Areaslot
    {
        public int structureNumber { get; set; }
        public int level { get; set; }
        public int floor { get; set; }
        public int height { get; set; }
        public int slotPurposeCode { get; set; }
        public int slotArea { get; set; }
        public int crowdAllowance { get; set; }
    }

}
