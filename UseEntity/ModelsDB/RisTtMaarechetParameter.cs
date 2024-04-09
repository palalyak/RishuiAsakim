using System;
using System.Collections.Generic;

namespace Infrastructure.ModelsDB
{
    public partial class RisTtMaarechetParameter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SugParameter { get; set; }
        public string ErechParameter { get; set; }
        public string IpAddress { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
