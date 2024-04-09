using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class RisTxBaaleyInyanLebakasha
    {
        public int PkCodeBaaleyInyanLebakasha { get; set; }
        public int FkCodeBaaleyInyanBtik { get; set; }
        public int FkCodeBakasha { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? IsActive { get; set; }
    }
}
