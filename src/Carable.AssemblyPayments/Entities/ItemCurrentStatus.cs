using System;
using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public class ItemCurrentStatus
    {
        [JsonProperty(PropertyName = "id")]
        public string ItemId { get; set; }

        [JsonProperty(PropertyName = "status")]
        public ItemStatus Status { get; set; }
    }
}
