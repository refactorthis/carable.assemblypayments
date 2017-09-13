using Newtonsoft.Json;
using Carable.AssemblyPayments.Internals;

namespace Carable.AssemblyPayments.ValueTypes
{
    /// <summary>
    /// Who pays the fee (buyer, seller, cc, int_wire)
    /// </summary>
    [JsonConverter(typeof(FeePayerToJsonConverter))]
    public enum FeePayer
    {
        /// <summary>
        /// Default value
        /// </summary>
        None,
        /// <summary>
        /// The fee is paid by the buyer
        /// </summary>
        Buyer,
        /// <summary>
        /// The fee is paid by the seller
        /// </summary>
        Seller,
        CC,
        IntWire,
        PaypalPayout // 
    }
}