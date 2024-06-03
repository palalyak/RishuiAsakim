using System;
using System.Collections.Generic;

namespace Infrastructure.ModelsDB
{
    public partial class RisTBakasha
    {
        public int PkCodeBakasha { get; set; }
        public int PkCodeEssek { get; set; }
        public int MisparBakasha { get; set; }
        public int? KodStatusHabakasha { get; set; }
        public DateTime? TaarichHagashatHabakasha { get; set; }
        public int? MisparHagasha { get; set; }
        public bool? NidrashOrech { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? IsActive { get; set; }
        public bool? Mvutal { get; set; }
        public string Heara { get; set; }
        public string MeidaMikdami { get; set; }
        public int? KSibaIBchiratEssekKodem { get; set; }
        public int? SugBakashaRishaionHeiter { get; set; }
        public bool? SwShinuiMivneBuza { get; set; }
        public bool? SwTatzhir { get; set; }
        public DateTime? TaarichSiumTipul { get; set; }
        public string TeudatZehutMagish { get; set; }
        public int? KodStatusHagasha { get; set; }
        public bool? SwReforma { get; set; }
        public DateTime? TrStatusHagasha { get; set; }
        public decimal? ShetachPargod { get; set; }
        public DateTime? TaarichPtira { get; set; }
        public int? FkKodStatusBakashaLehasava { get; set; }
        public int? MishtameshMevatel { get; set; }
        public int? SibatBitul { get; set; }
        public DateTime? TaarichBitul { get; set; }
    }
}
