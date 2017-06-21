using Newtonsoft.Json;
using PromisePayDotNet.Internals;

namespace PromisePayDotNet.Dto
{
    /// <summary>
    /// The receiver of a fee.
    /// </summary>
    [JsonConverter(typeof(ReceiverOfFeeJsonConverter))]
    public enum ReceiverOfFee
    {
        None,
        Buyer, 
        Seller, 
        CC, 
        IntWire,
        PaypalPayout
    }
}