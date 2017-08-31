using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Carable.AssemblyPayments.Entities;
using Carable.AssemblyPayments.Entities.Requests;

namespace Carable.AssemblyPayments.Abstractions
{
    /// <summary> 
    /// </summary>
    public interface ICallbackRepository
    {
        /// <summary>
        /// Create a Callback to notify you at the URL when the object_type changes
        /// </summary>
        Task<Callback> CreateCallbackAsync(CallbackRequest content);

        /// <summary>
        /// Retrieve an ordered and paginated list of all created Callbacks. (Max 200)
        /// </summary>
        Task<CallbacksList> GetCallbacksAsync(GetCallbacksRequest content);

        /// <summary>
        /// Show details of a specific Callback using a given :id.
        /// </summary>
        Task<Callback> GetCallbackAsync(string id);

        /// <summary>
        /// Update an existing Callback using a given :id.
        /// You can change the URL, the object_type and whether the Callback is enabled or disabled.
        /// </summary>
        Task<Callback> UpdateCallbackAsync(string id, CallbackRequest content);

        /// <summary>
        /// Delete an existing Callback using a given :id.
        /// </summary>
        Task<bool> DeleteCallbackAsync(string id);
    }
}
