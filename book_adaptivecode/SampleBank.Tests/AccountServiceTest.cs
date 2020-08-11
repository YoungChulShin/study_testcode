using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var sut = new AccountService();

            // act
            sut.AddingTransactionToAccount("예금계좌", 200m);

            // assert
            Assert.Fail();
        }
    }
}
