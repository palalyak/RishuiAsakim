using System;
using System.Collections.Generic;

namespace Infrastructure.ModelsDB
{
    public partial class RisTtSugHeiterNilve
    {
        public int Code { get; set; }
        public int SugCheadush { get; set; }
        public bool? HimNidrashTashlumHagra { get; set; }
        public bool? HimTaloiBerishaion { get; set; }
        public DateTime? TarichTchilatHiter { get; set; }
        public DateTime? TarichSiomHiter { get; set; }
        public int? TkufatHiterMin { get; set; }
        public int? TkufatHiterMax { get; set; }
        public int? MisparChodashiomLechidush { get; set; }
        public int? FkSugAvodotTashtit { get; set; }
        public int? FkCodeTlutSugHeiterNilve { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? IsActive { get; set; }
        public string Teur { get; set; }
        public string FkKvuzatMaut { get; set; }
        public DateTime? TarichSiomOnatHiter { get; set; }
        public DateTime? TarichTchilatOnatHiter { get; set; }
    }
}
