using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Apux
{

    public interface IApuxActionResult : IApuxAction
    {

        /// <summary>
        /// Dispatch flag
        /// This flag is used to dispatch a new action from the result of another action
        /// The root dispatcher will look for this flag, and if found attempt to dispatch the action result as a new action
        /// (is true by default when creating an action result from an existing action)
        /// </summary>
        /// <returns></returns>
        bool Dispatch { get; set; }

        /// <summary>
        /// Action result payload
        /// (Is always a JSON payload)
        /// </summary>
        /// <returns></returns>
        JToken Payload { get; set; }

        /// <summary>
        /// Any errors returned from action
        /// </summary>
        /// <returns></returns>
        List<ApuxError> Errors { get; set; }
    }

}