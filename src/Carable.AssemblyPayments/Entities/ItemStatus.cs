namespace Carable.AssemblyPayments.Entities
{
    /// <summary>
    /// Emum representation of the Status Int
    /// </summary>
    public enum ItemStatus
    {
        ///Transaction has not started yet, no payment received or requested.
        Pending = 22000,
        ///Payment has been requested by the seller to the buyer.
        PaymentRequired = 22100,
        ///The buyer has acknowledged that they are wiring the funds in, they are on their way.
        WirePending = 22110,
        ///The buyer has acknowledged that they have paid by PayPal, the funds are being cleared by PayPal.
        PaypalPending = 22111,
        ///Direct debit payment has been triggered, awaiting for these funds to clear.
        PaymentPending = 22150,
        ///Payment has been held as automatic triggers have been alerted. This will go through a manual review to move on to payment_deposited, or fraud_hold.
        PaymentHeld = 22175,
        ///A credit card payment has been authorized for capture.
        PaymentAuthorized = 22180,
        ///A previous credit card payment authorization has been voided.
        Voided = 22195,
        ///Payment is acknowledged as fraud, these funds will attempt to be refunded.
        FraudHold = 22190,
        ///Payment has been successfully received in our escrow vault.
        PaymentDeposited = 22200,
        ///Seller has requested release, they have delivered the goods or service.
        WorkCompleted = 22300,
        ///A dispute has been raised by either the buyer/seller, transaction is on hold until it is resolved.
        ProblemFlagged = 22400,
        ///The other party (who didn’t raise the dispute) has requested that the dispute should be resolved.
        ProblemResolveRequested = 22410,
        ///The dispute has not been resolved and has been escalated. This will go into a process of third party litigation.
        ProblemEscalated = 22420,
        ///The Item is completed, funds have been released.
        Completed = 22500,
        ///The Item is cancelled and can no longer be accessed.
        Cancelled = 22575,
        ///The funds have been refunded to the funding source of the buyer.
        Refunded = 22600,
        ///A refund action is initiated, but prior action is needed before the refund is applied (for example, the platform is waiting on a bank deposit or a batch processing).
        RefundPending = 22610,
        ///The funds will be refunded to the funding source of the buyer, after manual review to approve the refund.
        RefundFlagged = 22650,
        ///The funds have been refunded to the buyer through a means outside of the platform.
        OffPlatformRefunded = 22670,
        ///Partial release of funds have been requested by the seller in the transaction.
        PartialCompleted = 22700,
        ///Partial release of funds have occurred in the transaction.
        PartialPaid = 22800,
        ///The funds have been charged back by the buyer’s issuing bank through a means outside of the platform.
        OffPlatformChargedback = 22680
    }
}