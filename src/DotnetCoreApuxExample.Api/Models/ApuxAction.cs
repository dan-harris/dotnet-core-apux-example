using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.Models
{
    public class ApuxAction<T> : IApuxAction
    {

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "payload")]
        public T Payload { get; set; }

        [JsonIgnore]
        public JToken BasePayload { get; set; }

        public ApuxAction(string action)
        {
            Type = action;
            Payload = default(T);
            BasePayload = new JObject();
        }

        public ApuxAction(string action, T payload)
        {
            Type = action;
            Payload = payload;
            BasePayload = serializePayload(payload);
        }

        public ApuxAction(string action, JToken payload)
        {
            Type = action;
            Payload = deserializePayload(payload);
            BasePayload = payload;
        }

        public ApuxAction(ApuxAction<JToken> action)
        {
            Type = action.Type;
            Payload = deserializePayload(action.Payload);
            BasePayload = action.Payload;
        }

        public ApuxAction(IApuxAction action)
        {
            Type = action.Type;
            Payload = deserializePayload(action.BasePayload);
            BasePayload = action.BasePayload;
        }

        private JToken serializePayload(T payload)
        {
            if (payload is JToken) return payload as JToken;
            else if (payload is Array) return JArray.FromObject(payload);
            else if (payload is Object) return JToken.FromObject(payload);
            else return new JValue(payload);
        }

        private T deserializePayload(JToken payload)
        {
            if (payload != null) return payload.ToObject<T>();
            else return default(T);
        }
    }

}