using Carable.AssemblyPayments.ValueTypes;
using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    public class User : AbstractEntity
    {
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// Unique to platform.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        /// <summary>
        /// International number format. Include ’+’ and no spaces.
        /// </summary>
        [JsonProperty(PropertyName = "mobile")]
        public string Mobile { get; set; }
        /// <summary>
        /// Address: line1
        /// </summary>
        [JsonProperty(PropertyName = "address_line1")]
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Address: line2
        /// </summary>
        [JsonProperty(PropertyName = "address_line2")]
        public string AddressLine2 { get; set; }
        /// <summary>
        /// Address: city
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        /// <summary>
        /// Address: zip
        /// </summary>
        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }

        /// <summary>
        /// Address: state
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
        /// <summary>
        /// The verification status for the user
        /// </summary>
        [JsonProperty(PropertyName="verification_state")]
        public UserVerificationStatus VerificationState { get; set; }
        /// <summary>
        /// ISO 3166-1 alpha-3 country code (3 char)
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        /// <summary>
        /// Date of Birth (DD/MM/YYYY).
        /// </summary>
        [JsonProperty(PropertyName = "dob")]
        public string Dob { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "drivers_license")]
        public string DriversLicense { get; set; }
        /// <summary>
        /// Generic property for important KYC data. eg. SSN for US users, TFN for AU users.
        /// </summary>
        [JsonProperty(PropertyName = "government_number")]
        public string GovernmentNumber { get; set; }
    }
}
