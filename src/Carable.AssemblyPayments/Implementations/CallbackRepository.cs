using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Carable.AssemblyPayments.Abstractions;
using Carable.AssemblyPayments.Entities;
using Carable.AssemblyPayments.Entities.Requests;
using Carable.AssemblyPayments.Internals;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Implementations
{
    internal class CallbackRepository : AbstractRepository, ICallbackRepository
    {
        public CallbackRepository(IRestClient client, ILoggerFactory loggerFactory, IOptions<Settings.AssemblyPaymentsSettings> options)
            : base(client, loggerFactory.CreateLogger<CallbackRepository>(), options)
        {
        }
        
        public async Task<Callback> CreateCallbackAsync(CallbackRequest content)
        {
            var request = new RestRequest("/callbacks", HttpMethod.Post, content);
            var response = await SendRequestAsync(Client, request);
            return JsonConvert.DeserializeObject<IDictionary<string, Callback>>(response.Content).Values.First();
        }

        public async Task<CallbacksList> GetCallbacksAsync(GetCallbacksRequest content)
        {
            var request = new RestRequest("/callbacks", HttpMethod.Get, content);
            var response = await SendRequestAsync(Client, request);
            return JsonConvert.DeserializeObject<CallbacksList>(response.Content);
        }

        public async Task<Callback> GetCallbackAsync(string id)
        {
            var request = new RestRequest($"/callbacks/{id}", HttpMethod.Get);
            var response = await SendRequestAsync(Client, request);
            return JsonConvert.DeserializeObject<IDictionary<string, Callback>>(response.Content).Values.First();
        }

        public async Task<Callback> UpdateCallbackAsync(string id, CallbackRequest content)
        {
            var request = new RestRequest($"/callbacks/{id}", HttpMethod.Put, content);
            var response = await SendRequestAsync(Client, request);
            return JsonConvert.DeserializeObject<IDictionary<string, Callback>>(response.Content).Values.First();
        }

        public async Task<bool> DeleteCallbackAsync(string id)
        {
            var request = new RestRequest($"/callbacks/{id}", HttpMethod.Delete);
            var response = await SendRequestAsync(Client, request);
            if (response.StatusCode == HttpStatusCode.OK) return true;
            return false;
        }
    }
}
