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

        private readonly Func<string, IApuxActionDispatcher> _actions;
        private readonly IApuxActionDispatcher _allActions;

        public ActionsController(Func<string, IApuxActionDispatcher> actions)
        {
            _actions = actions;
            _allActions = _actions(Constants.ActionNamespace.ALL);
        }

        // POST endpoint for all actions
        [HttpPost("v1")]
        public IApuxActionResult ExecuteAction([FromBody] ApuxActionRequest actionRequest)
        {

            if (actionRequest == null)
            {
                throw new ArgumentNullException(nameof(actionRequest));
            }

            return _allActions.Dispatch(new ApuxAction<JToken>(actionRequest.Type, actionRequest.Payload));
        }

    }
}
