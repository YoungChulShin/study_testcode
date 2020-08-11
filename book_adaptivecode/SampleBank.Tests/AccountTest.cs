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

        [TestMethod]
        public void Adding100TransactionChangesBalance()
        {
            // arrange
            var account = new Account();

            // act
            account.AddTransaction(100m);

            // assert
            Assert.AreEqual(100m, account.Balance);
        }

        [TestMethod]
        public void AddingTransactionsCreatesSummationBalance()
        {
            // arrange
            var account = new Account();
            account.AddTransaction(50m);

            // act
            account.AddTransaction(30m);

            // assert
            Assert.AreEqual(80m, account.Balance);
        }
    }
}
