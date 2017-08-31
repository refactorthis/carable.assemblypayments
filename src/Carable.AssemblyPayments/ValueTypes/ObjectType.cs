using System;
using System.Collections.Generic;
using System.Text;

namespace Carable.AssemblyPayments.ValueTypes
{
    /// <summary>
    /// Object or entity to which the callbacks refer
    /// </summary>
    public enum ObjectType
    {
        None,
        Items,
        Users,
        Companies,
        Addresses,
        Accounts,
        Disbursements,
        Transactions,
        BatchTransactions

    }
}
