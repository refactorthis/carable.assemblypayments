using Newtonsoft.Json;
using Carable.AssemblyPayments.Internals;
using System.ComponentModel;

namespace Carable.AssemblyPayments.ValueTypes
{
    /// <summary>
    /// Who pays the fee (buyer, seller, cc, int_wire)
    /// </summary>
    [JsonConverter(typeof(DescriptionJsonConverter<FeePayer>))]
    public enum FeePayer
    {
        /// <summary>
        /// Default value
        /// </summary>
        [Description("")]
        None,
        /// <summary>
        /// The fee is paid by the buyer
        /// </summary>
        [Description("buyer")]
        Buyer,
        /// <summary>
        /// The fee is paid by the seller
        /// </summary>
        [Description("seller")]
        Seller,
        [Description("cc")]
        CC,
        [Description("int_wire")]
        IntWire,
        [Description("paypal_payout")]
        PaypalPayout // 
    }
}