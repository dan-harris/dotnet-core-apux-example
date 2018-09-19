using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Apux
{
    public class ApuxActionResultBase : ApuxActionBase
    {
        [JsonIgnore]
        public bool Dispatch { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public ApuxError[] Errors { get; set; }

        public ApuxActionResultBase(params ApuxError[] errors) : this("", null, errors) { }

        public ApuxActionResultBase(string type, params ApuxError[] errors) : this(type, null, errors) { }

        public ApuxActionResultBase(string type, JToken basePayload, params ApuxError[] errors) : base(type, basePayload)
        {
            Dispatch = !string.IsNullOrEmpty(type);
            Errors = errors;
        }
    }
}
