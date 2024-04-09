using System;
using System.Collections.Generic;

namespace Infrastructure.ModelsDB
{
    public partial class RisTMautBrishayonLeesek
    {
        public int PkMautRisahyunEsek { get; set; }
        public int FkRishyunEsek { get; set; }
        public int? FkMautBakasha { get; set; }
        public DateTime? TaarichTchilatTokefHarishaion { get; set; }
        public bool? Mevutal { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? IsActive { get; set; }
        public int? SugRishayon { get; set; }
        public DateTime? TaarichSyumTokefHarishaion { get; set; }
        public DateTime? TaarichPkiatShimushChoreg { get; set; }
    }
}
