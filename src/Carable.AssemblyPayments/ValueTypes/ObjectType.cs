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
        ///<summary>
        /// Default value. Does not Indicates an object type.
        ///</summary>
        None,
        ///<summary>
        /// Items
        ///</summary>
        Items,
        ///<summary>
        /// Users
        ///</summary>
        Users,
        ///<summary>
        /// Companies ()
        ///</summary>
        Companies,
        ///<summary>
        /// Addresses
        ///</summary>
        Addresses,
        ///<summary>
        /// Accounts
        ///</summary>
        Accounts,
         ///<summary>
        /// Disbursements
        ///</summary>
        Disbursements,
        ///<summary>
        /// Transactions
        ///</summary>
        Transactions,
        ///<summary>
        ///Batch Transactions
        ///</summary>
        BatchTransactions
    }
}
