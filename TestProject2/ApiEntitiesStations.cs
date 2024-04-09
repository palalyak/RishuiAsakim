using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestProject2
{
    public class ApiEntitiesStations
    {
        [JsonPropertyName("requestItemId")]
        public int RequestItemId { get; set; }

        [JsonPropertyName("stationName")]
        public string StationName { get; set; }

        [JsonPropertyName("lastStatus")]
        public string LastStatus { get; set; }

        [JsonPropertyName("lastUpdateDate")]
        public DateTime LastUpdateDate { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public class StationType
    {
        [JsonPropertyName("external")]
        public bool External { get; set; }

        [JsonPropertyName("allowEarlyCondition")]
        public bool AllowEarlyCondition { get; set; }

        [JsonPropertyName("notRequiredForLicense")]
        public bool NotRequiredForLicense { get; set; }

        [JsonPropertyName("comments")]
        public string Comments { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}