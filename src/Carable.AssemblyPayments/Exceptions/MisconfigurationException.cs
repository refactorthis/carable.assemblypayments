using System;

namespace Carable.AssemblyPayments.Exceptions
{
    public class MisconfigurationException : Exception
    {
        public MisconfigurationException(string message) : base(message)
        {
        }
    }
}
