using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public class PayPalAccount : AbstractAccount
    {
        [JsonProperty(PropertyName = "paypal")]
        public PayPal PayPal { get; set; }
    }
}
