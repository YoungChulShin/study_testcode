using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBank
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;

        public AccountService(IAccountRepository accountRepository)
        {
            repository = accountRepository;
        }

        public void AddTransactionToAccount(string accountName, decimal transactionAmount)
        {
            
        }
    }
}
