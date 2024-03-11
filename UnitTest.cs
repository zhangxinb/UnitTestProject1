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
            double value = 100.0;//this is a test

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

        /*
         [TestMethod]
        public void TestTransactionConstructor_TransactionTime()
        {
            // Arrange
            Account fromAccount = new Account(1);
            fromAccount.Transaction(200.0); // Add some balance to the account
            Account toAccount = new Account(2);
            double value = 100.0;

            // Act
            Transaction transaction = new Transaction(fromAccount, toAccount, value);

            // Assert
            Assert.IsTrue((DateTime.Now - transaction.Time).TotalSeconds < 1);
        }
        */

       
    }

    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void TestAccountConstructor_ValidId()
        {
            // Arrange
            int id = 1;

            // Act
            Account account = new Account(id);

            // Assert
            Assert.AreEqual(id, account.AccountId);
        }

        [TestMethod]
        public void TestAccountBalance_InitialBalance()
        {
            // Arrange
            Account account = new Account(1);

            // Assert
            Assert.AreEqual(0.0, account.Balance);
        }

        [TestMethod]
        public void TestAccountTransaction_AddPositiveValue()
        {
            // Arrange
            Account account = new Account(1);
            double value = 100.0;

            // Act
            bool result = account.Transaction(value);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(value, account.Balance);
        }

        [TestMethod]
        public void TestAccountTransaction_SubtractValue()
        {
            // Arrange
            Account account = new Account(1);
            account.Transaction(200.0); // Add some balance to the account
            double value = 100.0;

            // Act
            bool result = account.Transaction(-value);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(100.0, account.Balance);
        }

        [TestMethod]
        public void TestAccountTransaction_SubtractMoreThanBalance()
        {
            // Arrange
            Account account = new Account(1);
            account.Transaction(100.0); // Add some balance to the account
            double value = 200.0;

            // Act
            bool result = account.Transaction(-value);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(100.0, account.Balance);
        }

        [TestMethod]
        public void TestAccountTransaction_AddNegativeValue()
        {
            // Arrange
            Account account = new Account(1);
            double value = -100.0;

            // Act
            bool result = account.Transaction(value);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0.0, account.Balance);
        }

        [TestMethod]
        public void TestAccountInterestPct_SetAndGet()
        {
            // Arrange
            Account account = new Account(1);
            double interestPct = 5.0; // 5%

            // Act
            account.InterestPct = interestPct;

            // Assert
            Assert.AreEqual(interestPct, account.InterestPct);
        }

        [TestMethod]
        public void TestAccountInterestPct_SetNegativeValue()
        {
            // Arrange
            Account account = new Account(1);
            double interestPct = -5.0; // -5%

            // Act
            account.InterestPct = interestPct;

            // Assert
            Assert.AreEqual(0.0, account.InterestPct); // Assuming that the interest rate cannot be negative
        }

        [TestMethod]
        public void TestAccountInterestRate_SetAndGet()
        {
            // Arrange
            Account account = new Account(1);
            double interestRate = 0.05; // 5%

            // Act
            account.InterestRate = interestRate;

            // Assert
            Assert.AreEqual(interestRate, account.InterestRate);
        }

        [TestMethod]
        public void TestAccountInterestRate_SetNegativeValue()
        {
            // Arrange
            Account account = new Account(1);
            double interestRate = -0.05; // -5%

            // Act
            account.InterestRate = interestRate;

            // Assert
            Assert.AreEqual(0.0, account.InterestRate); // Assuming that the interest rate cannot be negative
        }
    }

    [TestClass]
    public class AddTransactionTest
    {
        [TestMethod]
        public void TestAddTransaction_ValidParameters()
        {
            // Arrange
            Bank bank = new Bank();
            Account fromAccount = bank.FindAccount(100000); // Assuming this account exists in the bank
            fromAccount.Transaction(200.0); // Add some balance to the account
            Account toAccount = bank.FindAccount(100011); // Assuming this account exists in the bank
            double value = 100.0;

            // Act
            bool result = bank.AddTransaction(toAccount, fromAccount, value);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(100.0, fromAccount.Balance, 0.001);
            Assert.AreEqual(100.0, toAccount.Balance, 0.001);
        }

        [TestMethod]
        public void TestAddTransaction_InsufficientBalance()
        {
            // Arrange
            Bank bank = new Bank();
            Account fromAccount = bank.FindAccount(100000); // Assuming this account exists in the bank
            Account toAccount = bank.FindAccount(100011); // Assuming this account exists in the bank
            double value = 200.0;

            // Act
            bool result = bank.AddTransaction(toAccount, fromAccount, value);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0.0, fromAccount.Balance, 0.001);
            Assert.AreEqual(0.0, toAccount.Balance, 0.001);
        }

        [TestMethod]
        public void TestAddTransaction_SameAccount()
        {
            // Arrange
            Bank bank = new Bank();
            Account fromAccount = bank.FindAccount(100000); // Assuming this account exists in the bank
            fromAccount.Transaction(200.0); // Add some balance to the account
            double value = 100.0;

            // Act
            bool result = bank.AddTransaction(fromAccount, fromAccount, value);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(200.0, fromAccount.Balance, 0.001);
        }

        [TestMethod]
        public void TestAddTransaction_NonExistentAccount()
        {
            // Arrange
            Bank bank = new Bank();
            Account fromAccount = new Account(999999); // This account does not exist in the bank
            fromAccount.Transaction(200.0); // Add some balance to the account
            Account toAccount = bank.FindAccount(100000); // Assuming this account exists in the bank
            double value = 100.0;

            // Act
            bool result = bank.AddTransaction(toAccount, fromAccount, value);

            // Assert
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class BankTest
    {
        [TestMethod]
        public void TestListAccounts()
        {
            // Arrange
            Bank bank = new Bank();

            // Act
            int[] accountIds = bank.ListAccounts();

            // Assert
            Assert.AreEqual(10, accountIds.Length); // Assuming the bank has 10 accounts by default
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(100000 + i, accountIds[i]); // Assuming the default account ids are 100000, 100001, ..., 100009
            }
        }

        [TestMethod]
        public void TestFindAccount_ValidId()
        {
            // Arrange
            Bank bank = new Bank();
            int id = 100000; // Assuming this account exists in the bank

            // Act
            Account account = bank.FindAccount(id);

            // Assert
            Assert.IsNotNull(account);
            Assert.AreEqual(id, account.AccountId);
        }

        [TestMethod]
        public void TestFindAccount_InvalidId()
        {
            // Arrange
            Bank bank = new Bank();
            int id = 999999; // Assuming this account does not exist in the bank

            // Act
            Account account = bank.FindAccount(id);

            // Assert
            Assert.IsNull(account);
        }
    }
}
