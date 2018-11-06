using Newtonsoft.Json;
using Carable.AssemblyPayments.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carable.AssemblyPayments.Entities
{
    public class Item : AbstractEntity
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "deposit_reference")]
        public string DepositReference { get; set; }

        [JsonProperty(PropertyName = "payment_type_id")]
        public PaymentType PaymentType { get; set; }

        // The request and response models differ but are represented as one model,
        // this is to ensure that serialization will set the payment_type field which is required for Item creation.
        [JsonProperty(PropertyName = "payment_type")]
        private PaymentType PaymentTypeId
        {
            get { return PaymentType; }
        }

        /// <summary>
        /// The status of the item
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public ItemStatus Status { get; set; }
        
        [JsonProperty(PropertyName = "net_amount")]
        public int? NetAmount { get; set; }
        [JsonProperty(PropertyName = "refunded_amount")]
        public int? RefundedAmount { get; set; }
        [JsonProperty(PropertyName = "released_amount")]
        public int? ReleasedAmount { get; set; }
        [JsonProperty(PropertyName = "chargedback_amount")]
        public int? ChargedbackAmount { get; set; }

        [JsonProperty(PropertyName = "refund_state")]
        public ItemRefundStatus? RefundState { get; set; }
        [JsonProperty(PropertyName = "refund_message")]
        public string RefundMessage { get; set; }
        [JsonProperty(PropertyName = "refund_amount")]
        public int? RefundAmount { get; set; }


        /// <summary>
        /// The cost in cents
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public long Amount { get; set; }

        [JsonProperty(PropertyName = "buyer_id")]
        public string BuyerId { get; set; }

        [JsonProperty(PropertyName = "buyer_name")]
        public string BuyerName { get; set; }

        [JsonProperty(PropertyName = "buyer_country")]
        public string BuyerCountry { get; set; }

        [JsonProperty(PropertyName = "buyer_email")]
        public string BuyerEmail { get; set; }

        [JsonProperty(PropertyName = "seller_id")]
        public string SellerId { get; set; }

        [JsonProperty(PropertyName = "seller_name")]
        public string SellerName { get; set; }

        [JsonProperty(PropertyName = "seller_country")]
        public string SellerCountry { get; set; }

        [JsonProperty(PropertyName = "seller_email")]
        public string SellerEmail { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonIgnore]
        public List<Fee> Fees { get; set; }

        /// <summary>
        /// Gets the fee identifiers, used to serialize
        /// </summary>
        /// <value>The fee identifiers.</value>
        [JsonProperty(PropertyName = "fee_ids")]
        public string FeeIds {
            get
            {
                if (Fees == null || !Fees.Any())
                {
                    return null;
                }
                return string.Join(",", Fees.Select(x => x.Id));
            }
        }

    }
}
