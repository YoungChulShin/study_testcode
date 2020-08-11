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
            // given
            var account = new Account();

            // when
            account.AddTransaction(200m);

            // then
            Assert.AreEqual(200m, account.Balance);
        }
    }
}
