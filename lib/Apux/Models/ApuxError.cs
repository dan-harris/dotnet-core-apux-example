using Newtonsoft.Json;

namespace Apux
{
    public class ApuxError
    {
        public enum ErrorType
        {
            ERROR = 0,
            WARNING = 1
        }

        [JsonProperty(PropertyName = "type")]
        public ErrorType Type { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}