using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public class CallbackLinks
    {
        /// <summary>
        /// List callbacks
        /// </summary>
        [JsonProperty("self")]
        public string Self { get; set; }
        /// <summary>
        /// Retrieve an ordered and paginated list of the responses garnered from a callback using a given :id.
        /// </summary>
        [JsonProperty("responses")]
        public string Responses { get; set; }
    }
}