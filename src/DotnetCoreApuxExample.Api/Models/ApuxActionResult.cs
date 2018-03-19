using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.Models
{
    public class ApuxActionResult<T> : IApuxActionResult
    {

        [JsonProperty(PropertyName = "payload")]
        public JToken Payload { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public List<AppError> Errors { get; set; }

        public ApuxActionResult(T payload)
        {
            Payload = serializePayload(payload);
        }

        public ApuxActionResult(List<AppError> errors)
        {
            Errors = errors;
        }

        public ApuxActionResult(T payload, List<AppError> errors)
        {
            Payload = serializePayload(payload);
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

    public interface IApuxActionResult
    {
        JToken Payload { get; set; }
        List<AppError> Errors { get; set; }
    }
}