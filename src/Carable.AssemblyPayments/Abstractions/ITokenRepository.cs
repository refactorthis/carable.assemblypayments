using Carable.AssemblyPayments.Entities;
using Carable.AssemblyPayments.Internals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carable.AssemblyPayments.Abstractions
{
    public interface ITokenRepository
    {
        /// <summary>
        /// https://reference.assemblypayments.com/#token-auth
        /// Create a card token that can be used with the PromisePay.js package to securely send Assembly credit card details.
        /// </summary>
        Task<CardToken> GenerateCardTokenAsync(string tokenType, string userId);
    }
    public static class TokenRepositoryExtensions
    {
        public static CardToken GenerateCardToken(this ITokenRepository repo, string tokenType, string userId) => repo.GenerateCardTokenAsync(tokenType, userId).WrapResult();
    }
}
