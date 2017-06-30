﻿using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public abstract class AbstractAccount : AbstractEntity
    {
        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }
    }
}
