using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBank
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;

        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public void AddTransactionToAccount(string accountName, decimal transactionAmount)
        {
            var account = repository.getByName(accountName);
            account.AddTransaction(transactionAmount);
        }
    }
}
