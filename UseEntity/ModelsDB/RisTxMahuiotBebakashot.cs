using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class RisTxMahuiotBebakashot
    {
        public int PkKesherMaut { get; set; }
        public int FkCodeParit { get; set; }
        public int FkBakasha { get; set; }
        public bool? AimMvutal { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? IsActive { get; set; }
    }
}
