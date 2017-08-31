using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities.Requests
{
    /// <summary>
    /// Parameters that are needed to list callbacks
    /// </summary>
    public class GetCallbacksRequest
    {
        /// <summary>
        /// Number of records to retrieve (up to 200)
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; } = 200;

        /// <summary>
        /// Number of records to offset for pagination
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Narrow down records to relevant character string
        /// </summary>
        [JsonProperty("filter")]
        public string Filter { get; set; } = string.Empty;
    }
}