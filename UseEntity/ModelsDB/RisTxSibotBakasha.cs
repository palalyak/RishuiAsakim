using System;
using System.Collections.Generic;

namespace Infrastructure.ModelsDB
{
    public partial class RisTxSibotBakasha
    {
        public int PkCodeSibotBakasha { get; set; }
        public int PkCodeBakasha { get; set; }
        public int KodSiba { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? IsActive { get; set; }
    }
}
