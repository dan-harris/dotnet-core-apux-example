using System;
using Microsoft.AspNetCore.Mvc;
using DotnetCoreApuxExample.Api.Models;
using DotnetCoreApuxExample.Api.Actions;
using Newtonsoft.Json.Linq;

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
        public ApuxActionResult ExecuteAction([FromBody] ApuxAction<JToken> actionRequest)
        {

            if (actionRequest == null)
            {
                throw new ArgumentNullException(nameof(actionRequest));
            }

            return _allActions.executeAction(actionRequest);
        }

    }
}
