using Carable.AssemblyPayments.Entities;

namespace Carable.AssemblyPayments.Abstractions
{
    public interface ICardAccountRepository
    {

        CardAccount GetCardAccountById(string cardAccountId);

        CardAccount CreateCardAccount(CardAccount cardAccount);

        bool DeleteCardAccount(string cardAccountId);

        User GetUserForCardAccount(string cardAccountId);

    }
}
