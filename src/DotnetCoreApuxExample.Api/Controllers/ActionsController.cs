using Apux;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public ApuxActionBase ExecuteAction([FromBody] ApuxActionBase actionRequest)
        {

            if (actionRequest == null)
            {
                throw new ArgumentNullException(nameof(actionRequest));
            }

            return _rootActionDispatcher.RootDispatch(actionRequest);
        }
    }
}
