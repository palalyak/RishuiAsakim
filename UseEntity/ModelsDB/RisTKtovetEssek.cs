using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class RisTKtovetEssek
    {
       public int PkCodeKtovetEssek { get; set; }
        public int PkCodeEssek { get; set; }
        public int? SugKtovet { get; set; }
        public int? SemelRechov { get; set; }
        public int? KodBait { get; set; }
        public string Knisa { get; set; }
        public int? KodKoma { get; set; }
        public string Mikud { get; set; }
        public string Dira { get; set; }
        public string TaDoar { get; set; }
        public decimal? Gush { get; set; }
        public decimal? Helka { get; set; }
        public int? KodMerkazMischari { get; set; }
        public int? MisparChanut { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IpAddress { get; set; }
        public bool? IsActive { get; set; }
        public byte[] RowVersion { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? MisparShchuna { get; set; }
        public int? BusinessHistoryId { get; set; }
    }
}
