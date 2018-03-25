using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Apux
{
    public interface IApuxAction
    {
        /// <summary>
        /// Type of action 
        /// (used by dispatchers to direct action to appropriate handler)
        /// </summary>
        /// <returns></returns>
        string Type { get; set; }

        /// <summary>
        /// Base Payload for action
        /// the JSON payload carried by action can be an empty JObject)
        /// </summary>
        /// <returns></returns>
        JToken BasePayload { get; set; }
    }
}