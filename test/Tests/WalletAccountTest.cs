using Newtonsoft.Json;
using Xunit;
using Carable.AssemblyPayments.Entities;
using System;
using Carable.AssemblyPayments.Abstractions;

namespace Carable.AssemblyPayments.Tests
{
    public class WalletAccountTest : AbstractTest
    {
        [Fact]
        public void WalletAccountDeserialization()
        {
            var content = "{\"id\":\"385b50bb-237a-42cb-9382-22953e191ae6\",\"active\":true,\"created_at\":\"2016-04-12T08:13:10.709Z\",\"updated_at\":\"2016-04-12T09:22:31.645Z\",\"balance\":12000,\"currency\":\"AUD\",\"links\":{\"self\":\"/wallet_accounts/385b50bb-237a-42cb-9382-22953e191ae6\",\"users\":\"/wallet_accounts/385b50bb-237a-42cb-9382-22953e191ae6/users\",\"disbursements\":\"/wallet_accounts/385b50bb-237a-42cb-9382-22953e191ae6/disbursements\"}}";
            var walletAccount = JsonConvert.DeserializeObject<WalletAccount>(content);
            Assert.Equal("385b50bb-237a-42cb-9382-22953e191ae6", walletAccount.Id);
            Assert.Equal("AUD", walletAccount.Currency);
            Assert.Equal(12000, walletAccount.Balance);
        }

        [Fact]
        public void DepositSuccessfully()
        {
            var content = Files.ReadAllText("./Fixtures/wallet_account_deposit.json");
            var client = GetMockClient(content);
            var repo = Get<IWalletAccountRepository>(client.Object);

            var id = "ec9bf096-c505-4bef-87f6-18822b9dbf2c";
            var accountId = "ec9bf096-c505-4bef-87f6-18822b9dbf2c";

            var disbursement = repo.DepositFunds(id, accountId, 5000);
            Assert.NotNull(disbursement);
            Assert.NotNull(disbursement.Id);
            Assert.NotNull(disbursement.CreatedAt);
            Assert.NotNull(disbursement.UpdatedAt);

            Assert.Equal(5000, disbursement.Amount);
            Assert.Equal("pending", disbursement.State);
            Assert.Equal("AUD", disbursement.Currency);
        }

        [Fact]
        public void WithdrawSuccessfully()
        {
            var content = Files.ReadAllText("./Fixtures/wallet_account_withdrawal.json");
            var client = GetMockClient(content);
            var repo = Get<IWalletAccountRepository>(client.Object);

            var id = "ec9bf096-c505-4bef-87f6-18822b9dbf2c";
            var accountId = "ec9bf096-c505-4bef-87f6-18822b9dbf2c";

            var disbursement = repo.WithdrawFunds(id, accountId, 10000);
            Assert.NotNull(disbursement);
            Assert.NotNull(disbursement.Id);
            Assert.NotNull(disbursement.CreatedAt);
            Assert.NotNull(disbursement.UpdatedAt);

            Assert.Equal(10000, disbursement.Amount);
            Assert.Equal("pending", disbursement.State);
            Assert.Equal("AUD", disbursement.Currency);
        }

        [Fact]
        public void GetWalletAccountSuccessfully()
        {
            var id = "385b50bb-237a-42cb-9382-22953e191ae6";
            var content = Files.ReadAllText("./Fixtures/wallet_account_get_by_id.json");
            var client = GetMockClient(content);
            var repo = Get<IWalletAccountRepository>(client.Object);

            var gotAccount = repo.GetWalletAccountById(id);

            Assert.Equal(id, gotAccount.Id);
        }

        [Fact]
        public void GetWalletAccountEmptyId()
        {
            var client = GetMockClient("");

            var repo = Get<IWalletAccountRepository>(client.Object);

            Assert.Throws<ArgumentException>(() => repo.GetWalletAccountById(string.Empty));
        }

        [Fact]
        public void GetUserForPayPalAccountSuccessfully()
        {
            var id = "5830def0-ffe8-11e5-86aa-5e5517507c26";

            var content = Files.ReadAllText("./Fixtures/wallet_account_get_users.json");
            var client = GetMockClient(content);
            var repo = Get<IWalletAccountRepository>(client.Object);

            var userId = "5830def0-ffe8-11e5-86aa-5e5517507c66"; //some user created before

            var gotUser = repo.GetUserForWalletAccount(id);

            Assert.NotNull(gotUser);
            Assert.Equal(userId, gotUser.Id);
        }

    }
}
