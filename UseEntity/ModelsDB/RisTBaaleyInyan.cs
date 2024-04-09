using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class RisTBaaleyInyan
    {
        public string PkMezaheBaalInyan { get; set; }
        public int? MisparBait { get; set; }
        public string MisparKnisa { get; set; }
        public string MisparKuma { get; set; }
        public string ShemMispaha { get; set; }
        public string ShemPrati { get; set; }
        public int? SkSemelMegurim { get; set; }
        public int? SkSemelYeshuv { get; set; }
        public int? TarichPtira { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IpAddress { get; set; }
        public bool? IsActive { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public int? FkSugZihui { get; set; }
        public string ShemChevra { get; set; }
    }
}
