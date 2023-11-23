using Newtonsoft.Json;

namespace RoadStatus
{
    [Serializable]
    public class Road
    {
        [JsonProperty("displayName")]
        public string? displayName { get; set; }
        [JsonProperty("statusSeverity")]
        public string? statusSeverity { get; set; }
        [JsonProperty("statusSeverityDescription")]
        public string? statusSeverityDescription { get; set; }
    }
}