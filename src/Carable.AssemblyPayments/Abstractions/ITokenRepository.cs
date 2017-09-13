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
        /// Create a token that can be used with the PromisePay.js package to securely communicate with Assembly Payments.
        /// </summary>
        Task<CardToken> GenerateTokenAsync(string tokenType, string userId);
    }
    public static class TokenRepositoryExtensions
    {
        public static CardToken GenerateToken(this ITokenRepository repo, string tokenType, string userId) => repo.GenerateTokenAsync(tokenType, userId).WrapResult();
    }
}
