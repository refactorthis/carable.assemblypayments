﻿using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public class ItemStatus
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
    }
}