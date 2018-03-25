using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Apux
{
    public class ApuxActionRequest : IApuxAction
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "payload")]
        public JToken Payload { get; set; }

        [JsonIgnore]
        public JToken BasePayload { get; set; }
    }

}