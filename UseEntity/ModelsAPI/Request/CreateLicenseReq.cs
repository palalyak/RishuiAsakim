using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Request
{

    public class CreateLicenseReq
    {
        public int requestId { get; set; }
        public int fileType { get; set; }
        public Licenseitem[] licenseItems { get; set; }
    }

    public class Licenseitem
    {
        public int requestItemId { get; set; }
        public string startLicenseDate { get; set; }
        public string endLicenseDate { get; set; }
        public int licenseItemType { get; set; }
    }

}
