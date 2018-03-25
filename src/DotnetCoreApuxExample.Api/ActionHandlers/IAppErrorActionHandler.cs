using System;
using Apux;
using DotnetCoreApuxExample.Api.Actions;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{

    public interface IAppErrorActionHandler
    {

        ApuxActionResult<JToken> UnknownActionHandler(UnknownActionAction action);
        ApuxActionResult<JToken> InternalErrorActionHandler(InternalErrorAction action);

    }
}