using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class RisTRishayonLeesek
    {
        public int PkRishiunEsek { get; set; }
        public int FkCodeEssek { get; set; }
        public int? FkCodeBakasha { get; set; }
        public int? FkSugTufes { get; set; }
        public long? MisparRishayun { get; set; }
        public int? FkStatusRishayun { get; set; }
        public DateTime? TaarichKabalatRishaion { get; set; }
        public bool? PursamShimushCchoreg { get; set; }
        public bool? ChidushBeikvotMahut { get; set; }
        public bool? HidushBeikvotChariga { get; set; }
        public int? MisparRishaionLetetzuga { get; set; }
        public int? NidrashTashlumHagra { get; set; }
        public int? FkCodeShovarTashlumRishayon { get; set; }
        public bool? EssekBesikun { get; set; }
        public string Heara { get; set; }
        public bool? KavanaLebitul { get; set; }
        public int? FkBakasha { get; set; }
        public bool? Mevutal { get; set; }
        public int? MishtameshMevatel { get; set; }
        public int? FkSibatBitul { get; set; }
        public DateTime? TaarichBitulRishyun { get; set; }
        public int? FkRishayun { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? IsActive { get; set; }
    }
}
