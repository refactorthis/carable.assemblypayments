namespace Carable.AssemblyPayments.ValueTypes
{
    /// <summary>
    /// Emum representation of the Status Int
    /// </summary>
    public enum ItemStatus
    {
        ///<summary>
        ///Transaction has not started yet, no payment received or requested.
        ///</summary>
        Pending = 22000,
        ///<summary>
        ///Payment has been requested by the seller to the buyer.
        ///</summary>
        PaymentRequired = 22100,
        ///<summary>
        ///The buyer has acknowledged that they are wiring the funds in, they are on their way.
        ///</summary>
        WirePending = 22110,
        ///<summary>
        ///The buyer has acknowledged that they have paid by PayPal, the funds are being cleared by PayPal.
        ///</summary>
        PaypalPending = 22111,
        ///<summary>
        ///Direct debit payment has been triggered, awaiting for these funds to clear.
        ///</summary>
        PaymentPending = 22150,
        ///<summary>
        ///Payment has been held as automatic triggers have been alerted. This will go through a manual review to move on to payment_deposited, or fraud_hold.
        ///</summary>
        PaymentHeld = 22175,
        ///<summary>
        ///A credit card payment has been authorized for capture.
        ///</summary>
        PaymentAuthorized = 22180,
        ///<summary>
        ///A previous credit card payment authorization has been voided.
        ///</summary>
        Voided = 22195,
        ///<summary>
        ///Payment is acknowledged as fraud, these funds will attempt to be refunded.
        ///</summary>
        FraudHold = 22190,
        ///<summary>
        ///Payment has been successfully received in our escrow vault.
        ///</summary>
        PaymentDeposited = 22200,
        ///<summary>
        ///Seller has requested release, they have delivered the goods or service.
        ///</summary>
        WorkCompleted = 22300,
        ///<summary>
        ///A dispute has been raised by either the buyer/seller, transaction is on hold until it is resolved.
        ///</summary>
        ProblemFlagged = 22400,
        ///<summary>
        ///The other party (who didn’t raise the dispute) has requested that the dispute should be resolved.
        ///</summary>
        ProblemResolveRequested = 22410,
        ///<summary>
        ///The dispute has not been resolved and has been escalated. This will go into a process of third party litigation.
        ///</summary>
        ProblemEscalated = 22420,
        ///<summary>
        ///The Item is completed, funds have been released.
        ///</summary>
        Completed = 22500,
        ///<summary>
        ///The Item is cancelled and can no longer be accessed.
        ///</summary>
        Cancelled = 22575,
        ///<summary>
        ///The funds have been refunded to the funding source of the buyer.
        ///</summary>
        Refunded = 22600,
        ///<summary>
        ///A refund action is initiated, but prior action is needed before the refund is applied (for example, the platform is waiting on a bank deposit or a batch processing).
        ///</summary>
        RefundPending = 22610,
        ///<summary>
        ///The funds will be refunded to the funding source of the buyer, after manual review to approve the refund.
        ///</summary>
        RefundFlagged = 22650,
        ///<summary>
        ///The funds have been refunded to the buyer through a means outside of the platform.
        ///</summary>
        OffPlatformRefunded = 22670,
        ///<summary>
        ///Partial release of funds have been requested by the seller in the transaction.
        ///</summary>
        PartialCompleted = 22700,
        ///<summary>
        ///Partial release of funds have occurred in the transaction.
        ///</summary>
        PartialPaid = 22800,
        ///<summary>
        ///The funds have been charged back by the buyer’s issuing bank through a means outside of the platform.
        ///</summary>
        OffPlatformChargedback = 22680
    }
}