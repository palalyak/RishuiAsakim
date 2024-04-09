using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class RisTxSeruvToTotzaatSeruv
    {
        public int Code { get; set; }
        public int FkCodeSeruv { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public int FkTotzaatSeruv { get; set; }
        public bool? AimMeyuadLebitul { get; set; }
    }
}
