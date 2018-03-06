using System.ComponentModel;
using Carable.AssemblyPayments.Internals;
using Newtonsoft.Json;

namespace Carable.AssemblyPayments.ValueTypes
{
    [JsonConverter(typeof(DescriptionJsonConverter<UserVerificationStatus>))]
    public enum UserVerificationStatus
    {
        /// Waiting for information of the user to fulfil our KYC data requirements.
        [Description("pending")]
        Pending=23000,
        /// Information received, waiting for Assembly to Approve the KYC.
        [Description("pending_check")]
        PendingCheck=23100,
        /// Stage 1 of the KYC is approved.
        [Description("approved_kyc_check")]
        ApprovedKycCheck=23150,
        /// Stage 1 and underwriting of the user has been approved.
        [Description("approved")]
        Approved=23200,
    }
}
