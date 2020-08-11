using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleBank.exception;
using System;

namespace SampleBank.Tests
{
    [TestClass]
    public class AccountServiceTest
    {
        private Mock<Account> mockAccount;
        private Mock<IAccountRepository> mockRepository;
        private AccountService sut;

        [TestInitialize]
        public void setup()
        {
            mockAccount = new Mock<Account>();
            mockRepository = new Mock<IAccountRepository>();
            sut = new AccountService(mockRepository.Object);
        }

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
            mockRepository.Setup(x => x.getByName("예금계좌")).Returns(account);

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

            // act
            sut.AddTransactionToAccount("예금 계좌", 100m);

            // assert
        }

        [TestMethod]
        public void AccountExceptionsAreWrappedInThrowServiceException()
        {
            // arrange
            mockAccount.Setup(x => x.AddTransaction(100m)).Throws<DomainException>();
            mockRepository.Setup(x => x.getByName("예금 계좌")).Returns(mockAccount.Object);

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
