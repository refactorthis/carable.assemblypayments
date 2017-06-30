using Carable.AssemblyPayments.Exceptions;
using System;
using System.Threading.Tasks;

namespace Carable.AssemblyPayments.Internals
{
    internal static class TasksExtensions
    {
        public static T WrapResult<T>(this Task<T> task)
        {
            try
            {
                return task.Result;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException != null && (
                    ex.InnerException is ApiErrorsException 
                    || ex.InnerException is UnauthorizedException
                    || ex.InnerException is NotFoundException
                    || ex.InnerException is ArgumentException
                    || ex.InnerException is ValidationException))
                    throw ex.InnerException;
                throw;
            }
        }
    }
}
