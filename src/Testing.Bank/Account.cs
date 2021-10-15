using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing.Bank
{
    public class Account
    {
        private IList<Transaction> _transactions { get; set; }
        public IList<Transaction> Transactions
        {
            get => _transactions;
            set => _transactions = value ?? throw new Exception($"{nameof(Transactions)} shouldn't be null");
        }

        private User _user { get; set; }
        public User User
        {
            get => _user;
            set => _user = value ?? throw new Exception($"{nameof(User)} shouldn't be default");
        }

        private int _balance { get; set; }
        public int Balance
        {
            get => _balance;
            set => _balance = value;
        }


        public Account(User user, IList<Transaction> transactions)
        {
            User = user;
            Transactions = transactions;
            Balance = GetBalance();
        }

        public int GetBalance()
        {
            var deposits = Transactions.Where(transaction => transaction.Type == TransactionType.Deposit)
                .Sum(transaction => transaction.Amount);

            var withdraws = Transactions.Where(transaction => transaction.Type == TransactionType.Withdraw)
                .Sum(transaction => transaction.Amount);

            return deposits - withdraws;
        }

        public void Deposit(int amount, string description)
        {
            if (amount <= 0) throw new Exception($"{nameof(Transaction.Amount)} should be greater than zero");

            Transactions.Add(new Transaction(TransactionType.Deposit, amount, description));

            Balance = GetBalance();
        }
        public void Withdraw(int amount, string description)
        {
            if (amount <= 0) throw new Exception($"{nameof(Transaction.Amount)} should be greater than zero");
            if (Balance - amount < 0) throw new Exception($"{nameof(Transaction.Amount)} should be less than balance");

            Transactions.Add(new Transaction(TransactionType.Withdraw, amount, description));

            Balance = GetBalance();
        }
    }
}
