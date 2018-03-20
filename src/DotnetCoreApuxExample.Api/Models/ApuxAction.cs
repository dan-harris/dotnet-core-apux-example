using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.Models
{
    public class ApuxAction<T> : IApuxAction<T>
    {

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "payload")]
        public T Payload { get; set; }

        public ApuxAction(string action)
        {
            Type = action;
            Payload = default(T);
        }

        public ApuxAction(string action, T payload)
        {
            Type = action;
            Payload = payload;
        }

        public ApuxAction(string action, JToken payload)
        {
            Type = action;
            Payload = deserializePayload(payload);
        }

        public ApuxAction(ApuxAction<JToken> actionRequest)
        {
            Type = actionRequest.Type;
            Payload = deserializePayload(actionRequest.Payload);
        }

        private T deserializePayload(JToken payload)
        {
            if (payload != null) return payload.ToObject<T>();
            else return default(T);
        }
    }

}