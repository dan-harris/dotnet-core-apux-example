using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Apux
{
    public interface IApuxActionDispatcher
    {

        /// <summary>
        /// Dispatch an action to the appropriate handler, using its Action Type
        /// </summary>
        /// <param name="actionRequest">The dispatch request action</param>
        /// <returns></returns>
        IApuxActionResult Dispatch(ApuxAction<JToken> actionRequest);

    }
}