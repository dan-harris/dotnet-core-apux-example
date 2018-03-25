using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.Models
{

    public interface IApuxActionResult : IApuxAction
    {
        bool Dispatch { get; set; }
        JToken Payload { get; set; }
        List<AppError> Errors { get; set; }
    }

}