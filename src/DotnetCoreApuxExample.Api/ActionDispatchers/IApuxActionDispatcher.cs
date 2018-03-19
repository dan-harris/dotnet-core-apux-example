using System;
using System.Collections.Generic;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.ActionDispatchers
{
    public interface IApuxActionDispatcher
    {
        IApuxActionResult Dispatch(ApuxAction<JToken> actionRequest);

    }
}