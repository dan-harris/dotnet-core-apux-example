using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.Models
{
    public class ApuxActionResult
    {

        [JsonProperty(PropertyName = "data")]
        public JToken Data { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public List<AppError> Errors { get; set; }
    }
}