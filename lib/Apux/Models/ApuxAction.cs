using Newtonsoft.Json.Linq;

namespace Apux
{

    public class ApuxAction<T> : ApuxActionBase
    {

        public T Payload
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

        public ApuxAction(string action, JToken payload) : base(action, payload) { }

        public ApuxAction(string action, T payload) : this(action, payload == null ? null : JToken.FromObject(payload)) { }

        public ApuxAction(ApuxAction<T> token) : this(token.Type, token.BasePayload) { }

        public ApuxAction(ApuxActionBase action) : this(action.Type, action.BasePayload) { }

        public ApuxAction(string type, ApuxActionBase action) : this(type, action.BasePayload) { }
    }

}