using System;
using System.Collections.Generic;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.ActionDispatchers
{
    public interface IApuxActionRootDispatcher
    {
        IApuxActionResult RootDispatch(IApuxAction actionRequest);

        IApuxActionResult Dispatch(string actionNamespace, ApuxAction<JToken> action);

    }
}