using Newtonsoft.Json;
using Carable.AssemblyPayments.ValueTypes;

namespace Carable.AssemblyPayments.Entities
{
    /// <summary>
    /// Fee is associated with an Item
    /// </summary>
    public class Fee : AbstractEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "fee_type_id")]
        public FeeType FeeType { get; set; }
        /// <summary>
        /// Amount in cents
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }
        /// <summary>
        /// Cap the Fee
        /// </summary>
        [JsonProperty(PropertyName = "cap")]
        public string Cap { get; set; }
        /// <summary>
        /// Minimum Fee
        /// </summary>
        [JsonProperty(PropertyName = "min")]
        public string Min { get; set; }
        /// <summary>
        /// Maximum Fee
        /// </summary>
        [JsonProperty(PropertyName = "max")]
        public string Max { get; set; }
        /// <summary>
        /// Who pays the fee (buyer, seller, cc, int_wire)
        /// </summary>
        [JsonProperty(PropertyName = "to")]
        public FeePayer Payer { get; set; }
    }
}
