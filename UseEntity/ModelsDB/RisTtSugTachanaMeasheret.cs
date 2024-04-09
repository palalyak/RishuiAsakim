using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class RisTtSugTachanaMeasheret
    {
        public int Code { get; set; }
        public string Teur { get; set; }
        public bool SwChizoni { get; set; }
        public bool SwLeafsherTnaiMukdam { get; set; }
        public bool SwEnoMoneaRishayon { get; set; }
        public string Hearot { get; set; }
        public string Email { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? IsActive { get; set; }
        public bool? MevatzaBikurim { get; set; }
    }
}
