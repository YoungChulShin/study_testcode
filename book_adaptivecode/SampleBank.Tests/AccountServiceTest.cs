using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleBank.Tests.mock;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBank.Tests
{
    [TestClass]
    public class AccountServiceTest
    {
        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            // arrange
            var account = new Account();
            var fakeRepository = new FakeAccountRepository(account);
            var sut = new AccountService(fakeRepository);

            // act
            sut.AddTransactionToAccount("예금계좌", 200m);

            // assert
            Assert.AreEqual(200m, account.Balance);
        }
    }
}
