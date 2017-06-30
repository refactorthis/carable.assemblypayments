using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public class Upload : AbstractEntity
    {
        [JsonProperty(PropertyName = "total_lines")]
        public int? TotalLines { get; set; }

        [JsonProperty(PropertyName = "processed_lines")]
        public int? ProcessedLines { get; set; }

        [JsonProperty(PropertyName = "update_lines")]
        public int? UpdateLines { get; set; }

        [JsonProperty(PropertyName = "error_lines")]
        public int? ErrorLines { get; set; }

        [JsonProperty(PropertyName = "progress")]
        public double? progress { get; set; }

    }
}
