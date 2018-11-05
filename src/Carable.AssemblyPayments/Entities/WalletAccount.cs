using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public class WalletAccount : AbstractAccount
    {
        [JsonProperty(PropertyName = "balance")]
        public int Balance { get; set; }
    }
}
