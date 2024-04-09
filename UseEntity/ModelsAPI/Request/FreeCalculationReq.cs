using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Request
{

    public class FreeCalculationReq
    {
        public int additionalPermitTypeId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string endHour { get; set; }
        public string startHour { get; set; }
        public int area { get; set; }
        public Businessaddress businessAddress { get; set; }
    }

    public class Businessaddress
    {
        public int id { get; set; }
        public int liceningNumber { get; set; }
        public int requestNumber { get; set; }
        public string name { get; set; }
        public int streetId { get; set; }
        public string streetDesc { get; set; }
        public int houseNumber { get; set; }
    }


}
