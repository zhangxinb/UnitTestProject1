using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankToBeTested
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
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
                accounts[i] = new Account(first + i * 11);
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

        public Account FindAccount(int id)
        {
            int i = 0;

            if (ListAccounts().Contains(id))
                while (accounts[i] == null || (accounts[i] != null && accounts[i].AccountId != id))
                    i++;
            return accounts[i];
        }

        public bool AddTransaction(Account to, Account from, double value)
        {
            if (from.Balance < value)
            {
                transactions[transactionCount++] = new Transaction(to, from, value);
                return true;
            }
            return false;
        }

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
            return false;
        }
    }

    public class Transaction
    {
        private Account to, from;
        private DateTime time;
        private double transactionValue;

        public Transaction(Account _from, Account _to, double value)
        {
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

