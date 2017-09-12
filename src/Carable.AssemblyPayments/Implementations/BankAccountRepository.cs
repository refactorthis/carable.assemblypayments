using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Carable.AssemblyPayments.Entities;
using Carable.AssemblyPayments.Abstractions;
using Carable.AssemblyPayments.Internals;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Carable.AssemblyPayments.Implementations
{
    internal class BankAccountRepository : AbstractRepository, IBankAccountRepository
    {
        public BankAccountRepository(IRestClient client, ILoggerFactory loggerFactory, IOptions<Settings.AssemblyPaymentsSettings> options)
            : base(client, loggerFactory.CreateLogger<BankAccountRepository>(), options)
        {
        }

        public async Task<BankAccount> GetBankAccountByIdAsync(string bankAccountId)
        {
            AssertIdNotNull(bankAccountId);
            var request = new 
                RestRequest("/bank_accounts/{id}", Method.GET);
            request.AddUrlSegment("id", bankAccountId);
            var response = await SendRequestAsync(Client, request);
            return JsonConvert.DeserializeObject<IDictionary<string, BankAccount>>(response.Content).Values.First();
        }

        public async Task<BankAccount> CreateBankAccountAsync(BankAccount bankAccount)
        {
            var request = new RestRequest("/bank_accounts", Method.POST);
            request.AddParameter("user_id", bankAccount.UserId);
            request.AddParameter("bank_name", bankAccount.Details.BankName);
            request.AddParameter("account_name", bankAccount.Details.AccountName);
            request.AddParameter("routing_number", bankAccount.Details.RoutingNumber);
            request.AddParameter("account_number", bankAccount.Details.AccountNumber);
            request.AddParameter("account_type", bankAccount.Details.AccountType);
            request.AddParameter("holder_type", bankAccount.Details.HolderType);
            request.AddParameter("country", bankAccount.Details.Country);
            
            var response = await SendRequestAsync(Client, request);
            return JsonConvert.DeserializeObject<IDictionary<string, BankAccount>>(response.Content).Values.First();
        }

        public async Task<bool> DeleteBankAccountAsync(string bankAccountId)
        {
            AssertIdNotNull(bankAccountId);
            var request = new RestRequest("/bank_accounts/{id}", Method.DELETE);
            request.AddUrlSegment("id", bankAccountId);
            var response = await SendRequestAsync(Client, request);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            return true;
        }

        public async Task<User> GetUserForBankAccountAsync(string bankAccountId)
        {
            AssertIdNotNull(bankAccountId);
            var request = new RestRequest("/bank_accounts/{id}/users", Method.GET);
            request.AddUrlSegment("id", bankAccountId);
            RestResponse response = await SendRequestAsync(Client, request);

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
