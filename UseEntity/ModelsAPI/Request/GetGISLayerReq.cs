using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Request
{
    public class GetGISLayerReq
    {
        public int streetId { get; set; }
        public int houseNumber { get; set; }
    }

}
