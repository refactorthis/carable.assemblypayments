using Carable.AssemblyPayments.ValueTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Carable.AssemblyPayments.Entities.Requests
{
    /// <summary>
    /// Parameters that are needed to create a callback
    /// </summary>
    public class CallbackRequest
    {
        /// <summary>
        /// description to identify the callback
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// URL to which the callbacks will notify
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// object or entity to which the callbacks refer
        /// </summary>
        [JsonProperty("object_type"), JsonConverter(typeof(StringEnumConverter))]
        public ObjectType ObjectType { get; set; }
        /// <summary>
        /// toggle whether callback is active or inactive
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}