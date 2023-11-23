using Newtonsoft.Json;

namespace RoadStatus
{
    /// <summary>
    /// This DTO (Data Transfer Object) represents Road Enity in TFL Api
    /// </summary>
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