using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Carable.AssemblyPayments.Entities;
using Carable.AssemblyPayments.Abstractions;
using Carable.AssemblyPayments.Internals;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System;

namespace Carable.AssemblyPayments.Implementations
{
    internal class TokenRepository : AbstractRepository, ITokenRepository
    {
        public TokenRepository(IRestClient client, ILoggerFactory loggerFactory, IOptions<Settings.AssemblyPaymentsSettings> options)
            : base(client, loggerFactory.CreateLogger<TokenRepository>(), options)
        {
        }


        public async Task<CardToken> GenerateCardTokenAsync(string tokenType, string userId)
        {
            var request = new RestRequest("/token_auths", Method.POST);
            request.AddParameter("token_type", tokenType);
            request.AddParameter("user_id", userId);
            var response = await SendRequestAsync(Client, request);
            var dict = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
            if (dict.ContainsKey("token_auth"))
            {
                var itemCollection = dict["token_auth"];
                return JsonConvert.DeserializeObject<CardToken>(JsonConvert.SerializeObject(itemCollection));
            }
            return null;
        }
    }
}
