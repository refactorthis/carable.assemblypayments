using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public class CardAccount : AbstractAccount
    {
        [JsonProperty(PropertyName = "card")]
        public Card Card { get; set; }
    }
}
