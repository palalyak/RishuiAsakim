using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class RisTxMahuiotLebakasha
    {
        public int PkCodeParit { get; set; }
        public int PkCodeEssek { get; set; }
        public int KodParit { get; set; }
        public int KodMaslul { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsActive { get; set; }
        public int? CodeShelavNuchachi { get; set; }
        public bool? HosfatMautButzaBaesek { get; set; }
        public bool? NidrashTuchnitHadasha { get; set; }
        public int? SugHakpa { get; set; }
        public DateTime? TarichBitul { get; set; }
        public int? KvutzatShimushChoreg { get; set; }
        public bool? MahutRashit { get; set; }
        public bool? Mevotal { get; set; }
        public bool? Mokpe { get; set; }
        public int? ShimushChoregLeheiter { get; set; }
        public int? ShimushChoregLetaba { get; set; }
        public int? StatusHamahutBebakasha { get; set; }
        public DateTime? TaarichPkiatShimushChoreg { get; set; }
        public DateTime? TaarichStatus { get; set; }
        public DateTime? TarichMokpe { get; set; }
    }
}
