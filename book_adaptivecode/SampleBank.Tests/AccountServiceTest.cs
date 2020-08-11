using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleBank.Tests.mock;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBank.Tests
{
    [TestClass]
    public class AccountServiceTest
    {
        /*
         * 직접 구현한 Mock 적용
         * 
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
        */

        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            // arrange
            var account = new Account();
            var mockRepository = new Mock<IAccountRepository>();
            mockRepository.Setup(x => x.getByName("예금계좌")).Returns(account);
            var sut = new AccountService(mockRepository.Object);

            // act
            sut.AddTransactionToAccount("예금계좌", 200m);

            // assert
            Assert.AreEqual(200m, account.Balance);
        }
    }
}
