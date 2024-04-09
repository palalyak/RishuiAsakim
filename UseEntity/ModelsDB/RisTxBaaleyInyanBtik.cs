using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class RisTxBaaleyInyanBtik
    {
        public int PkBaaleyInyanBtik { get; set; }
        public int FkCodeEssek { get; set; }
        public string FkMezaheBaalInyan { get; set; }
        public int? SkMisparBakashaBapamHarishona { get; set; }
        public int? FkSugBaalInyan { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string DoarElectroni { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? IsActive { get; set; }
        public string StakeholderId1 { get; set; }
    }
}
