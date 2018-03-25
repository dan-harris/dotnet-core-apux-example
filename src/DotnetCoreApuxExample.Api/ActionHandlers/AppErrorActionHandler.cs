using System;
using System.Collections.Generic;
using Apux;
using DotnetCoreApuxExample.Api.Actions;
using DotnetCoreApuxExample.Api.Models;
using Newtonsoft.Json.Linq;

namespace DotnetCoreApuxExample.Api.ActionHandlers
{

    public class AppErrorActionHandler : IAppErrorActionHandler
    {

        public ApuxActionResult<JToken> UnknownActionHandler(UnknownActionAction action) => new ApuxActionResult<JToken>(
            new List<ApuxError> { new ApuxError { Type = ApuxError.ErrorType.ERROR, Value = "Unknown Action" } }
        );

        public ApuxActionResult<JToken> InternalErrorActionHandler(InternalErrorAction action) => new ApuxActionResult<JToken>(
            new List<ApuxError> { new ApuxError { Type = ApuxError.ErrorType.ERROR, Value = "Internal Error" } }
        );

    }
}