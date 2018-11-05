using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Carable.AssemblyPayments.Entities;
using Carable.AssemblyPayments.Abstractions;
using Carable.AssemblyPayments.Internals;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Carable.AssemblyPayments.Implementations
{
    internal class WalletAccountRepository : AbstractRepository, IWalletAccountRepository
    {
        private const string ResourceUri = "/wallet_accounts/";

        public WalletAccountRepository(IRestClient client, ILoggerFactory loggerFactory, IOptions<Settings.AssemblyPaymentsSettings> options)
            : base(client, loggerFactory.CreateLogger<PayPalAccountRepository>(), options)
        {
        }

        public async Task<WalletAccount> GetWalletAccountByIdAsync(string walletAccountId)
        {
            AssertIdNotNull(walletAccountId);

            var request = new RestRequest(ResourceUri + "{id}", Method.GET);
            request.AddUrlSegment("id", walletAccountId);

            var response = await SendRequestAsync(Client, request);
            return JsonConvert.DeserializeObject<IDictionary<string, WalletAccount>>(response.Content).Values.First();
        }

        public async Task<Disbursement> WithdrawFundsAsync(string walletAccountId, string accountId, int amount)
        {
            AssertIdNotNull(walletAccountId);
            AssertIdNotNull(accountId);
            
            var request = new RestRequest(ResourceUri + "{id}/withdrawal", Method.POST);
            request.AddUrlSegment("id", walletAccountId);
            request.AddParameter("account_id", accountId);
            request.AddParameter("amount", amount);

            var response = await SendRequestAsync(Client, request);

            var dict = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
            if (dict.ContainsKey("disbursements"))
            {
                var item = dict["disbursements"];
                return JsonConvert.DeserializeObject<Disbursement>(JsonConvert.SerializeObject(item));
            }
            return null;
        }

        public async Task<Disbursement> DepositFundsAsync(string walletAccountId, string accountId, int amount)
        {
            AssertIdNotNull(walletAccountId);
            AssertIdNotNull(accountId);

            var request = new RestRequest(ResourceUri + "{id}/deposit", Method.POST);
            request.AddUrlSegment("id", walletAccountId);
            request.AddParameter("account_id", accountId);
            request.AddParameter("amount", amount);

            var response = await SendRequestAsync(Client, request);

            var dict = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
            if (dict.ContainsKey("disbursements"))
            {
                var item = dict["disbursements"];
                return JsonConvert.DeserializeObject<Disbursement>(JsonConvert.SerializeObject(item));
            }
            return null;
        }

        public async Task<User> GetUserForWalletAccountAsync(string walletAccountId)
        {
            AssertIdNotNull(walletAccountId);

            var request = new RestRequest(ResourceUri + "{id}/users", Method.GET);
            request.AddUrlSegment("id", walletAccountId);

            var response = await SendRequestAsync(Client, request);
            var dict = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
            if (dict.ContainsKey("users"))
            {
                var item = dict["users"];
                return JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(item));
            }
            return null;
        }
    }
}
