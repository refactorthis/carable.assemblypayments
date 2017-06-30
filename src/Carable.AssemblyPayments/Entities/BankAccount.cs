using Carable.AssemblyPayments.ValueTypes;
using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public class BankAccount : AbstractAccount
    {
        [JsonProperty(PropertyName = "bank")]
        public Bank Bank { get; set; }
    }
}
