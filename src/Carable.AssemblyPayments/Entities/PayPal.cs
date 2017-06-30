using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public class PayPal
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}
