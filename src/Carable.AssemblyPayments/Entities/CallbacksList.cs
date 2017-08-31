using System.Collections.Generic;
using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public class CallbacksList
    {
        [JsonProperty("callbacks")]
        public List<Callback> Callbacks { get; set; }

        [JsonProperty("meta")]
        public CallbackListMeta Meta { get; set; }

        [JsonProperty("links")]
        public CallbackListLinks Links { get; set; }
    }

    public class CallbackListLinks
    {
        [JsonProperty("self")]
        public string Self { get; set; }
    }

    public class CallbackListMeta
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
