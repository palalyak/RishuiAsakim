using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Infrastructure.ModelsAPI.Request
{

    public class GetBusinessData
    {
        public Filter filter { get; set; }

        [JsonProperty("params")]
        public Params Params { get; set; }
    }

    public class Filter
    {
        public int businessId { get; set; }
    }

    public class Params
    {
        public string validityDate { get; set; }
        public bool withAddress { get; set; }
        public bool withMailAddress { get; set; }   
        public bool withItems { get; set; }
        public bool withLicense { get; set; }
        public bool withAdditionalPermit { get; set; }
        public bool withStakeholders { get; set; }
        public bool withWarnings { get; set; }
        public AddressParams addressParams { get; set; }
    }

    public class AddressParams
    {
        public bool withStreetDesc { get; set; }
        public bool neighborhoodDesc { get; set; }
        public int addressType { get; set; }
    }

}
