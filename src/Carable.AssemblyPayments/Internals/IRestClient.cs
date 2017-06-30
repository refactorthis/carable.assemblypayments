using System;
using System.Threading.Tasks;

namespace Carable.AssemblyPayments.Internals
{
    public interface IRestClient
    {
        Uri BaseUrl { get; set; }
        IAuthenticator Authenticator { get; set; }

        Task<RestResponse> ExecuteAsync(RestRequest request);
    }
}
