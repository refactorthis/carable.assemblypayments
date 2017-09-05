using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public class ItemCurrentStatus
    {
        [JsonProperty(PropertyName = "id")]
        public string ItemId { get; set; }

        [JsonProperty(PropertyName = "status")]
        public ItemStatus Status { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
    }
}
