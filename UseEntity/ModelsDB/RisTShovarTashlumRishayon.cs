using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class RisTShovarTashlumRishayon
    {
        public int PkCodeShovarTashlumRishayon { get; set; }
        public int FkCodeEssek { get; set; }
        public int? FkCodeRishayonEssek { get; set; }
        public int? FkCodeBakasha { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? IsActive { get; set; }
        public int? FkMisparHagasha { get; set; }
        public int? FkStatusTashlum { get; set; }
        public int? LuVoucherTypeCode { get; set; }
        public int? MisparMidaMukdam { get; set; }
        public int? MisparShuvar { get; set; }
        public decimal? SchumHaagra { get; set; }
        public int? SugShovar { get; set; }
        public DateTime? TaarichAcharonLetashlum { get; set; }
        public DateTime? TaarishTashlum { get; set; }
        public int? FkCodeBakashaLeiterNilve { get; set; }
    }
}
