using System;
using System.Collections.Generic;

namespace Testing.Bank.Tests.Fixtures
{
    public class AccountFixture : IDisposable
    {
        public Account Account;

        public AccountFixture()
        {
            Account = new Account(new User("Rick Sánchez", 70), new List<Transaction>()
            {
                new Transaction(TransactionType.Deposit, 100, $"Deposit 100 $"),
                new Transaction(TransactionType.Deposit, 200, $"Deposit 100 $"),
                new Transaction(TransactionType.Withdraw, 150, $"Withdraw 100 $"),
                new Transaction(TransactionType.Deposit, 100, $"Deposit 100 $"),
                new Transaction(TransactionType.Deposit, 100, $"Deposit 100 $"),
            });
        }

        public void Dispose()
        {
            Account = null;
        }
    }
}
