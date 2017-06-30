using System;
using System.Collections.Generic;

namespace Carable.AssemblyPayments.Exceptions
{
    public class ApiErrorsException : Exception
    {
        public Dictionary<string, List<string>> Errors { get; private set; }

        public ApiErrorsException(string message, Dictionary<string, List<string>> errors) : base(message)
        {
            Errors = errors;
        }
    }
}

