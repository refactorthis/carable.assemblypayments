using Carable.AssemblyPayments.Entities;
using System.Threading.Tasks;
using Carable.AssemblyPayments.Internals;

namespace Carable.AssemblyPayments.Abstractions
{
    public interface IWalletAccountRepository
    {
        Task<WalletAccount> GetWalletAccountByIdAsync(string walletAccountId);

        Task<Disbursement> WithdrawFundsAsync(string walletAccountId, string accountId, int amount);

        Task<Disbursement> DepositFundsAsync(string walletAccountId, string accountId, int amount);

        Task<User> GetUserForWalletAccountAsync(string walletAccountId);
    }

    public static class WalletAccountRepositoryExtensions
    {
        public static WalletAccount GetWalletAccountById(this IWalletAccountRepository repo, string walletAccountId)
        {
            return repo.GetWalletAccountByIdAsync(walletAccountId).WrapResult();
        }

        public static Disbursement WithdrawFunds(this IWalletAccountRepository repo, string walletAccountId, string accountId, int amount)
        {
            return repo.WithdrawFundsAsync(walletAccountId, accountId, amount).WrapResult();
        }

        public static Disbursement DepositFunds(this IWalletAccountRepository repo, string walletAccountId, string accountId, int amount)
        {
            return repo.DepositFundsAsync(walletAccountId, accountId, amount).WrapResult();
        }

        public static User GetUserForWalletAccount(this IWalletAccountRepository repo, string walletAccountId)
        {
            return repo.GetUserForWalletAccountAsync(walletAccountId).WrapResult();
        }
    }
}
