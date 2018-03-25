using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.Models
{
    public interface IApuxAction
    {
        string Type { get; set; }

        JToken BasePayload { get; set; }
    }
}