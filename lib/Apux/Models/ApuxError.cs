using Newtonsoft.Json;

namespace Apux
{
    public class ApuxError
    {
        public enum ErrorType
        {
            ERROR = 0,
            WARNING = 1
        }

        [JsonIgnore]
        private ErrorType _type;
        [JsonIgnore]
        private ErrorType Type
        {
            set
            {
                ErrorName = value.ToString();
                _type = value;
            }
        }

        [JsonProperty(PropertyName = "type")]
        public string ErrorName { get; private set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        public ApuxError(ErrorType type, string value )
        {
            Type = type;
            Value = value;
        }
    }
}