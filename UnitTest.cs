using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod]
        public void TestTransactionConstructor_ValidParameters()
        {
            // Arrange
            Account fromAccount = new Account(1);
            fromAccount.Transaction(200.0); // Add some balance to the account
            Account toAccount = new Account(2);
            double value = 100.0;

            // Act
            Transaction transaction = new Transaction(fromAccount, toAccount, value);

            // Assert
            // If the constructor completes without throwing an exception, the test passes.
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTransactionConstructor_NegativeValue()
        {
            // Arrange
            Account fromAccount = new Account(1);
            Account toAccount = new Account(2);
            double value = -100.0;

            // Act
            Transaction transaction = new Transaction(fromAccount, toAccount, value);

            // Assert
            // The test will fail if the constructor does not throw an ArgumentOutOfRangeException.
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTransactionConstructor_InsufficientBalance()
        {
            // Arrange
            Account fromAccount = new Account(1);
            Account toAccount = new Account(2);
            double value = 100.0;

            // Act
            Transaction transaction = new Transaction(fromAccount, toAccount, value);

            // Assert
            // The test will fail if the constructor does not throw an ArgumentException.
        }

        [TestMethod]
        public void TestTransactionConstructor_ZeroValue()
        {
            // Arrange
            Account fromAccount = new Account(1);
            fromAccount.Transaction(200.0); // Add some balance to the account
            Account toAccount = new Account(2);
            double value = 0.0;

            // Act
            Transaction transaction = new Transaction(fromAccount, toAccount, value);

            // Assert
            // If the constructor completes without throwing an exception, the test passes.
        }

        [TestMethod]
        public void TestTransactionConstructor_ExactBalance()
        {
            // Arrange
            Account fromAccount = new Account(1);
            fromAccount.Transaction(100.0); // Add some balance to the account
            Account toAccount = new Account(2);
            double value = 100.0;

            // Act
            Transaction transaction = new Transaction(fromAccount, toAccount, value);

            // Assert
            // If the constructor completes without throwing an exception, the test passes.
        }

        [TestMethod]
        public void TestTransactionConstructor_BalanceUpdate()
        {
            // Arrange
            Account fromAccount = new Account(1);
            fromAccount.Transaction(200.0); // Add some balance to the account
            Account toAccount = new Account(2);
            double value = 100.0;

            // Act
            Transaction transaction = new Transaction(fromAccount, toAccount, value);

            // Assert
            Assert.AreEqual(100.0, fromAccount.Balance, 0.001);
            Assert.AreEqual(100.0, toAccount.Balance, 0.001);
        }
    }
}
