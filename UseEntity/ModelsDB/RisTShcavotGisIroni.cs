using System;
using System.Collections.Generic;

namespace Infrastructure.ModelsDB
{
    public partial class RisTShcavotGisIroni
    {
        public int PkShcavotGisIroni { get; set; }
        public int Rechov { get; set; }
        public int MisparBait { get; set; }
        public int? MisparKnisot { get; set; }
        public bool? RechovMercazi { get; set; }
        public bool? ChotzeRechovMercazi { get; set; }
        public bool? RechovMischari { get; set; }
        public int? FkMediniutLaila { get; set; }
        public int? MisparEzor { get; set; }
        public int? FkEzorYafo { get; set; }
        public int? FkMitcham { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? IsActive { get; set; }
    }
}
