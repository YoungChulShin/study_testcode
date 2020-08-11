using SampleBank.exception;
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
            if (repository == null)
            {
                throw new ArgumentNullException("repository", "유효한 저장소 객체를 제공해야 합니다");
            }

            this.repository = repository;
        }

        public void AddTransactionToAccount(string accountName, decimal transactionAmount)
        {
            var account = repository.getByName(accountName);
            if (account != null)
            {
                try
                {
                    account.AddTransaction(transactionAmount);
                }
                catch(DomainException e)
                {
                    throw new ServiceException();
                }
            }
        }
    }
}
