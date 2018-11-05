using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public class Disbursement : AbstractEntity
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("batch_id")]
        public string BatchId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
