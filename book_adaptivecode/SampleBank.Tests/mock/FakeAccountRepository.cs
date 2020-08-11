using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBank.Tests.mock
{
    public class FakeAccountRepository : IAccountRepository
    {
        private Account account;

        public FakeAccountRepository(Account account)
        {
            this.account = account;
        }

        public Account getByName(string name)
        {
            return account;
        }
    }
}
