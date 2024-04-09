using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class RisTHeiterNilve
    {
        public int Code { get; set; }
        public int FkCodeEssek { get; set; }
        public int? FkStatusHeiterNilve { get; set; }
        public DateTime? TaarichMin { get; set; }
        public DateTime? TaarichMax { get; set; }
        public int? CodeMishtameshMevatel { get; set; }
        public int? SibatBitol { get; set; }
        public bool? IndikatziaLemidrachaShetachPatuach { get; set; }
        public bool? IndikatziaToShetachDetailMivne { get; set; }
        public string Esber { get; set; }
        public DateTime? TaarichBitol { get; set; }
        public int? FkBakashaLheiterNilve { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? IsActive { get; set; }
        public decimal? MerchakMehamidracha { get; set; }
        public bool? Mevutal { get; set; }
        public int? FkSugHeiterNilve { get; set; }
    }
}
