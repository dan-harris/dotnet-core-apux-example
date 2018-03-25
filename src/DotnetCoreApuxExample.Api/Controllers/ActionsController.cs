using System;
using Microsoft.AspNetCore.Mvc;
using DotnetCoreApuxExample.Api.Models;
using DotnetCoreApuxExample.Api.Actions;
using Newtonsoft.Json.Linq;
using DotnetCoreApuxExample.Api.ActionDispatchers;

namespace DotnetCoreApuxExample.Api.Controllers
{
    [Route("api")]
    public class ActionsController : Controller
    {

        private readonly IApuxActionRootDispatcher _rootActionDispatcher;

        public ActionsController(IApuxActionRootDispatcher rootActionDispatcher)
        {
            _rootActionDispatcher = rootActionDispatcher;
        }

        // POST endpoint for all actions
        [HttpPost("v1")]
        public IApuxActionResult ExecuteAction([FromBody] ApuxActionRequest actionRequest)
        {

            if (actionRequest == null)
            {
                throw new ArgumentNullException(nameof(actionRequest));
            }

            return _rootActionDispatcher.Dispatch(new ApuxAction<JToken>(actionRequest.Type, actionRequest.Payload));
        }

    }
}
