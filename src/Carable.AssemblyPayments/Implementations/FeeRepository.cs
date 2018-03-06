using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Carable.AssemblyPayments.Entities;
using Carable.AssemblyPayments.Exceptions;
using Carable.AssemblyPayments.Abstractions;
using Carable.AssemblyPayments.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Carable.AssemblyPayments.ValueTypes;

namespace Carable.AssemblyPayments.Implementations
{
    internal class FeeRepository : AbstractRepository, IFeeRepository
    {
        public FeeRepository(IRestClient client, ILoggerFactory loggerFactory, IOptions<Settings.AssemblyPaymentsSettings> options)
            : base(client, loggerFactory.CreateLogger<FeeRepository>(), options)
        {
        }

        public async Task<IEnumerable<Fee>> ListFeesAsync()
        {
            var request = new RestRequest("/fees", Method.GET);
            var response = await SendRequestAsync(Client, request);
            var dict = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
            if (dict.ContainsKey("fees"))
            {
                var userCollection = dict["fees"];
                return JsonConvert.DeserializeObject<List<Fee>>(JsonConvert.SerializeObject(userCollection));
            }
            return new List<Fee>();
        }

        public async Task<Fee> GetFeeByIdAsync(string feeId)
        {
            AssertIdNotNull(feeId);
            var request = new RestRequest("/fees/{id}", Method.GET);
            request.AddUrlSegment("id", feeId);
            var response = await SendRequestAsync(Client, request);
            return JsonConvert.DeserializeObject<IDictionary<string, Fee>>(response.Content).Values.First();
        }

        class CreateFeeRequest
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "fee_type_id")]
            public int FeeType { get; set; }

            [JsonProperty(PropertyName = "amount")]
            public int Amount { get; set; }

            [JsonProperty(PropertyName = "cap")]
            public string Cap { get; set; }

            [JsonProperty(PropertyName = "min")]
            public string Min { get; set; }

            [JsonProperty(PropertyName = "max")]
            public string Max { get; set; }

            [JsonProperty(PropertyName = "to")]
            public FeePayer Payer { get; set; }
        }

        public async Task<Fee> CreateFeeAsync(Fee fee)
        {
            VailidateFee(fee);
            var request = new RestRequest("/fees", Method.POST, new CreateFeeRequest {
                Name = fee.Name,
                Amount = fee.Amount,
                Cap = fee.Cap,
                FeeType = (int)fee.FeeType,
                Max =fee.Max,
                Min = fee.Min,
                Payer = fee.Payer
            });

            var response = await SendRequestAsync(Client, request);
            return JsonConvert.DeserializeObject<IDictionary<string, Fee>>(response.Content).Values.First();
        }

        private void VailidateFee(Fee fee)
        {
            if (fee == null) throw new ArgumentNullException(nameof(fee));
            if (!_possibleFeePayers.Contains(fee.Payer))
            {
                throw new ValidationException(
                    "Payer should have value of "+string.Join(", ", _possibleFeePayers.Select(to=> $"\"{Enum.GetName(typeof(FeePayer), to)}\"")));
            }
        }

        private readonly List<FeePayer> _possibleFeePayers = new List<FeePayer> { 
               FeePayer.Buyer, FeePayer.Seller, FeePayer.CC, FeePayer.IntWire, FeePayer.PaypalPayout 
        };
    }
}
