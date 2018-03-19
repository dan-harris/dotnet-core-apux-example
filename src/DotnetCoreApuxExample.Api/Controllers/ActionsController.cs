using System;
using Microsoft.AspNetCore.Mvc;
using DotnetCoreApuxExample.Api.Models;
using DotnetCoreApuxExample.Api.Actions;

namespace DotnetCoreApuxExample.Api.Controllers
{
    [Route("api")]
    public class ActionsController : Controller
    {

        private readonly Func<string, IApuxAction> _actions;
        private readonly IApuxAction _allActions;

        public ActionsController(Func<string, IApuxAction> actions)
        {
            _actions = actions;
            _allActions = _actions(Constants.ActionNamespace.ALL);
        }

        // POST endpoint for all actions
        [HttpPost("v1")]
        public ApuxActionResult ExecuteAction([FromBody] ApuxActionRequest actionRequest)
        {

            if (actionRequest == null)
            {
                throw new ArgumentNullException(nameof(actionRequest));
            }

            return _allActions.executeAction(actionRequest);
        }

    }
}
