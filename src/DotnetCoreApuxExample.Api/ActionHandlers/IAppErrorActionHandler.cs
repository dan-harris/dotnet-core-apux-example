using System;
using DotnetCoreApuxExample.Api.Actions;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{

    public interface IAppErrorActionHandler
    {

        ApuxActionResult<JToken> UnknownActionHandler(UnknownActionAction action);

    }
}