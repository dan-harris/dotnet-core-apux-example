using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.Models
{
    public class ApuxAction<T>
    {
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }

        public ApuxAction(string action)
        {
            Action = action;
        }
    }
}