using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.ModelsAPI.BaseClass;

namespace Infrastructure.ModelsAPI.Response
{


    public class Ser062Res : Result
    {
        public Data data { get; set; }
        public Result result { get; set; }
    }

    public class Data
    {
        public bool additionalPermitPossibility { get; set; }
        public DateTime startValidityDate { get; set; }
        public bool isRenew { get; set; }
        public bool isFeeRequired { get; set; }
        public int maxPermitPeriod { get; set; }
        public int minPermitPeriod { get; set; }
        public object nightPermitStartHour { get; set; }
        public object nightPermitEndHour { get; set; }
        public object pergodPermitMaxArea { get; set; }
        public DateTime startPermitSeason { get; set; }
        public DateTime endPermitSeason { get; set; }
        public object[] impossibilityReasons { get; set; }
    }



}
