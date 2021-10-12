using System;

namespace Testing.Bank
{
    public class Account
    {
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
            set => _balance = value > 0
                ? value
                : throw new Exception($"{nameof(Balance)} should be greater than zero");
        }

        public Account(User user, int balance)
        {
            User = user;
            Balance = balance;
        }

        public void Deposit(int amount)
        {
            if (amount <= 0) throw new Exception($"{nameof(Transaction.Amount)} should be greater than zero");

            Balance += amount;
        }
        public void Withdraw(int amount)
        {
            if (amount <= 0) throw new Exception($"{nameof(Transaction.Amount)} should be greater than zero");
            if (Balance - amount < 0) throw new Exception($"{nameof(Transaction.Amount)} should be less than balance");

            Balance -= amount;
        }
    }
}
