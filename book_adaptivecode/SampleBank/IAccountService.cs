using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBank
{
    interface IAccountService
    {
        void AddTransactionToAccount(string accountName, decimal transactionAmount);
    }
}
