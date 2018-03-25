using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Apux
{
    public class ApuxActionResult<T> : IApuxActionResult
    {

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "payload")]
        public JToken Payload { get; set; }

        [JsonIgnore]
        public bool Dispatch { get; set; }

        [JsonIgnore]
        public JToken BasePayload { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public List<ApuxError> Errors { get; set; }

        public ApuxActionResult(T payload)
        {
            Type = "";
            Dispatch = false;
            Payload = serializePayload(payload);
            BasePayload = serializePayload(payload);
        }

        public ApuxActionResult(string type, T payload)
        {
            Type = type;
            Dispatch = !string.IsNullOrEmpty(type);
            Payload = serializePayload(payload);
            BasePayload = serializePayload(payload);
        }

        public ApuxActionResult(IApuxAction action)
        {
            Type = action.Type;
            Dispatch = !string.IsNullOrEmpty(action.Type);
            Payload = action.BasePayload;
            BasePayload = action.BasePayload;
        }


        public ApuxActionResult(List<ApuxError> errors)
        {
            Type = "";
            Dispatch = false;
            Payload = new JObject();
            BasePayload = new JObject();
            Errors = errors;
        }

        public ApuxActionResult(T payload, List<ApuxError> errors)
        {
            Type = "";
            Dispatch = false;
            Payload = serializePayload(payload);
            BasePayload = serializePayload(payload);
            Errors = errors;
        }

        private JToken serializePayload(T payload)
        {
            if (payload is JToken) return payload as JToken;
            else if (payload is Array) return JArray.FromObject(payload);
            else if (payload is Object) return JToken.FromObject(payload);
            else return new JValue(payload);
        }
    }

}