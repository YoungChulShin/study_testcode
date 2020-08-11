using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBank.Tests
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void AddingTransactionChangesBalance()
        {
            // arrange
            var account = new Account();

            // act
            account.AddTransaction(200m);

            // assert
            Assert.AreEqual(200m, account.Balance);
        }

        [TestMethod]
        public void AccountHaveAnOpeningBalanceOfZero()
        {
            // arrange

            // act
            var account = new Account();

            // assert
            Assert.AreEqual(0m, account.Balance);
        }
    }
}
