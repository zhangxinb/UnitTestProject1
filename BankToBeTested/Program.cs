using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class Bank
    {
        private Account[] accounts;
        private Transaction[] transactions;
        private int transactionCount;

        public Bank()
        {
            accounts = new Account[10];
            int i, first = 100000;

            for (i = 0; i < accounts.Length; i++)
            { 
            accounts[i] = new Account(first + i * 11);
            //accounts[i] = new Account(first + i);
            }
            // TestListAccounts()
            transactions = new Transaction[1000];
        }

        public int[] ListAccounts()
        {
            int[] list = new int[accounts.Length];
            int i = 0;
            foreach (Account acc in accounts)
            {
                if (acc != null)
                    list[i++] = acc.AccountId;
            }
            return list;
        }
        
         /*public int[] ListAccounts()
        {
            int[] list = new int[accounts.Length];
            for (int i = 0; i < accounts.Length; i++) // Change foreach loop to for loop
            {
                 if (accounts[i] != null)
                      list[i] = accounts[i].AccountId;
            }
              return list;
        }
         */

        public Account FindAccount(int id)
        {
            int i = 0;

            if (ListAccounts().Contains(id))
                while (accounts[i] == null || (accounts[i] != null && accounts[i].AccountId != id))
                    i++;
            return accounts[i];
        }

        /*public Account FindAccount(int id)
        {
            foreach (Account account in accounts)
            {
                if (account != null && account.AccountId == id)
                    return account;
            }
            return null; // Return null if the id is not found
        }
        */

        public bool AddTransaction(Account to, Account from, double value)
        {
            if (from.Balance < value)// >= TestAddTransaction_InsufficientBalance()
            {
                transactions[transactionCount++] = new Transaction(to, from, value);
                return true;
            }
            return false;
        }
        /*public bool AddTransaction(Account to, Account from, double value)
        {
         // Check if the accounts exist in the bank account list.TestAddTransaction_NonExistentAccount()
          if (to == null || from == null || !ListAccounts().Contains(to.AccountId) || !ListAccounts().Contains      (from.AccountId))
              return false;

            // Check if the two accounts are the same. TestAddTransaction_SameAccount()
          if (to.AccountId == from.AccountId)
                return false;

            // Check if the transaction value is higher than the balance of the "from" account
            if (from.Balance < value)
                return false;

            // If all checks pass, add the transaction
            transactions[transactionCount++] = new Transaction(to, from, value);
            return true;
        }*/
    }

    public class Account
    {
        private double balance = 0.0;
        private double interest = 0.0;
        private int accountId;

        public Account(int id)
        {
            accountId = id;
        }

        public int AccountId
        {
            get { return accountId; }
        }
        public double Balance
        {
            get { return balance; }
        }
        public double InterestPct
        {
            get { return interest * 100.0; }
            set { interest = value / 100.0; }
        }

        public double InterestRate
        {
            get { return interest; }
            set { interest = value; }
        }

        public bool Transaction(double val)
        {
            if (val >= 0)
            {
                balance += val;
                return true;
            }
            
            else if (balance >= val)
            {
                balance -= val;
                return true;
            }
            
             /*else if (val < 0 && balance >= Math.Abs(val))
            {
                balance -= Math.Abs(val);
                return true;
            }
            //TestAccountTransaction_SubtractValue(), TestAccountTransaction_SubtractMoreThanBalance()，TestAccountTransaction_AddNegativeValue(), TestAddTransaction_ValidParameters()
            */
            return false;
        }
    }

    public class Transaction
    {
        private Account to, from;
        private DateTime time;
        private double transactionValue;

        public Transaction(Account _from, Account _to, double value)
        //public Transaction(Account _to, Account _from, double value)
        {
            /*
            if (_from == null || _to == null)
                throw new ArgumentNullException(_from == null ? "from" : "to");
            */
            //to = _to;
            //from = _from;

            if (value < 0)
                throw new ArgumentOutOfRangeException("value", "Negative transaction value at constructor of class Transaction");
            if (value > from.Balance)
                throw new ArgumentException($"Invalid transaction, " +
                    $"balance {from.Balance} of the from account {from.AccountId} is less than the value {value} of the transaction", "value");
            to = _to;
            from = _from;
            time = DateTime.Now;
            transactionValue = value;
            to.Transaction(value);
            from.Transaction(-value);
        }


    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}

