using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Apux
{
    public class ApuxActionResult<T> : ApuxActionResultBase
    {

        T Payload
        {
            get
            {
                return BasePayload.ToObject<T>();
            }

            set
            {
                BasePayload = (value == null) ? null : JToken.FromObject(value);
            }
        }

        public ApuxActionResult(string type, T payload, params ApuxError[] errors) : base(type, payload == null ? null : JToken.FromObject(payload), errors) { }

        public ApuxActionResult(string type, JToken payload, params ApuxError[] errors) : base(type, payload, errors) { }

        public ApuxActionResult(T payload, params ApuxError[] errors) : this("", payload, errors) { }

        public ApuxActionResult(ApuxActionBase action, params ApuxError[] errors) : this(action.Type, action.BasePayload, errors) { }

        public ApuxActionResult(ApuxAction<T> actionResult, params ApuxError[] errors) : this(actionResult.Type, actionResult.Payload, errors) { }

        public ApuxActionResult(params ApuxError[] errors) : this("", new JObject(), errors) { }

    }

}