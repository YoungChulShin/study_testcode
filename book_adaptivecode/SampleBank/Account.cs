using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBank
{
    public class Account
    {
        public decimal Balance
        {
            get;
            private set;
        }

        public Account()
        {
            Balance = 200m;
        }

        public void AddTransaction(decimal amount)
        {

        }
    }
}
