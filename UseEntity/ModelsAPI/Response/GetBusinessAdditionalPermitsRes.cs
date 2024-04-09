using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Response
{
    public class GetBusinessAdditionalPermitsRes
    {
        public int id { get; set; }
        public int requestAdditionalPermitId { get; set; }
        public bool isValid { get; set; }
        public int additionalPermitTypeId { get; set; }
        public string additionalPermitTypeDesc { get; set; }
        public string mainItemDescription { get; set; }
        public DateTime validityStartDate { get; set; }
        public DateTime validityEndDate { get; set; }
        public object cancelDate { get; set; }
        public object cancelUserId { get; set; }
        public object cancelReasonId { get; set; }
        public object cancelReasonDesc { get; set; }
        public object closeDay { get; set; }
        public object determinedEndHour { get; set; }
        public object determinedStartHour { get; set; }
        public int quantityTable { get; set; }
        public object quantityBarTable { get; set; }
        public int quantityChairs { get; set; }
        public object determinedArea { get; set; }
        public object additionaPermitFileUrl { get; set; }
        public float determinedDistanceSidewalk { get; set; }
        public object[] additionalPermitCondition { get; set; }
    }

}


