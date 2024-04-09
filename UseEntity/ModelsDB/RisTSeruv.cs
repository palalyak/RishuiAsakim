using System;
using System.Collections.Generic;

namespace Infrastructure.ModelsDB
{
    public partial class RisTSeruv
    {
        public int Code { get; set; }
        public int SugSeruv { get; set; }
        public DateTime TaarichLebitulRishayon { get; set; }
        public int? CodeTozzatTeumShimua { get; set; }
        public DateTime? TaarichShimuaMetuchnan { get; set; }
        public DateTime? TaarichShimuaBefoal { get; set; }
        public int? CodeHachlatatShimua { get; set; }
        public int? CodeSiumTipulShimua { get; set; }
        public bool? AimTipulBeseruvSium { get; set; }
        public DateTime TaarichIdkunAcharon { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public int? LuRefuseTypeCode { get; set; }
        public DateTime TaarichHasiruvHamakori { get; set; }
        public DateTime TaarichLabitulAlpiShimoa { get; set; }
        public DateTime TaarichMakoriLabitulRishion { get; set; }
        public DateTime? TaarichLabitulHeiterimAlpiShimoa { get; set; }
    }
}
