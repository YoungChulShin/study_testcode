using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleBank.exception;
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAccountServiceWithNullAccountRepository()
        {
            // arrange

            // act
            var sut = new AccountService(null);

            // assert
        }

        [TestMethod]
        public void DoNotThrowWhenAccountIsNotFound()
        {
            // arrange
            var mockRepository = new Mock<IAccountRepository>();
            var sut = new AccountService(mockRepository.Object);

            // act
            sut.AddTransactionToAccount("예금 계좌", 100m);

            // assert
        }

        [TestMethod]
        public void AccountExceptionsAreWrappedInThrowServiceException()
        {
            // arrange
            var accountMock = new Mock<Account>();
            accountMock.Setup(x => x.AddTransaction(100m)).Throws<DomainException>();

            var mockRepository = new Mock<IAccountRepository>();
            mockRepository.Setup(x => x.getByName("예금 계좌")).Returns(accountMock.Object);

            var sut = new AccountService(mockRepository.Object);

            // act
            try
            {
                sut.AddTransactionToAccount("예금 계좌", 100m);
            }
            catch (ServiceException e)
            {
                // assert
                Assert.IsInstanceOfType(e.InnerException, typeof(DomainException));
            }
        }
    }
}
