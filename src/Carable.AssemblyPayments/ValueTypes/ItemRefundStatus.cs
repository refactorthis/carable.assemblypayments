namespace Carable.AssemblyPayments.ValueTypes
{
    /// <summary>
    /// Item refund states. From https://reference.assemblypayments.com/#item-refund-states
    /// </summary>
    public enum ItemRefundStatus
    {
        /// <summary>
        /// A refund has been initiated by the seller.
        /// </summary>
        Pending=22600,
        /// <summary>
        /// A refund has been requested by the buyer.
        /// </summary>
        Requested=22620,
        /// <summary>
        /// The refund has been triggered and is being processed.
        /// </summary>
        Processing=22622,
        /// <summary>
        /// The refund is awaiting the direct debit from the seller’s bank account. Once the funds are direct-debited, these will be returned to the item’s funding source.
        /// </summary>
        PendingReturn=22630,
        /// <summary>
        /// The refund is being processed for direct credit to the buyer’s bank account. The item will be marked a success after 1 business day, if the funds do not bounce.
        /// </summary>
        PendingDirectCredit=22640,
        /// <summary>
        /// The refund attempt has failed due to an invalid funding source. This could be due to an expired card or insufficient funds.
        /// </summary>
        Failed=22660,
        /// <summary>
        /// The refund has been successfully completed.
        /// </summary>
        Success=22690,
    }
}