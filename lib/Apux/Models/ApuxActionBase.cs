using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Apux
{
    [Serializable]
    public class ApuxActionBase
    { 
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "payload")]
        protected internal JToken BasePayload { get; set; }

        public ApuxActionBase(string type)
        {
            Type = type;
        }

        [JsonConstructor]
        public ApuxActionBase(string type, JToken basePayload)
        {
            Type = type;
            BasePayload = basePayload;
        }
    }
}
