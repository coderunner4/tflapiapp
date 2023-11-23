using Newtonsoft.Json;

namespace RoadStatus
{
    [Serializable]
    public class TFLServiceException
    {
        [JsonProperty("exceptionType")]
        public string? exceptionType {get; set;}        
        [JsonProperty("httpStatusCode")]
        public int? httpStatusCode {get; set;}
        [JsonProperty("message")]
        public string? message {get; set;}
    }
}