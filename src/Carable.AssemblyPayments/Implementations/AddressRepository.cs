using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Carable.AssemblyPayments.Entities;
using Carable.AssemblyPayments.Abstractions;
using Carable.AssemblyPayments.Internals;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carable.AssemblyPayments.Implementations
{
    internal class AddressRepository : AbstractRepository, IAddressRepository
    {
        public AddressRepository(IRestClient client, ILoggerFactory loggerFactory, IOptions<Settings.AssemblyPaymentsSettings> options)
            : base(client, loggerFactory.CreateLogger<AddressRepository>(), options)
        {
        }

        public async Task<Address> GetAddressByIdAsync(string addressId)
        {
            AssertIdNotNull(addressId);
            var request = new RestRequest("/addresses/{id}", Method.GET);
            request.AddUrlSegment("id", addressId);
            var response = await SendRequestAsync(Client, request);
            return JsonConvert.DeserializeObject<IDictionary<string, Address>>(response.Content).Values.First(); 
        }
    }
}
