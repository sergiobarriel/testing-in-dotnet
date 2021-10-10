using System;
using Xunit;

namespace Testing.Bank.Tests
{
    public class TransactionShould
    {
        [Fact]
        public void UserWithoutName_ThrowsException()
        {
            // Arrange
            var type = TransactionType.Deposit;
            var amount = 10;
            var description = string.Empty;

            // Act
            Action action = () => { _ = new Transaction(type, amount, description); };

            // Assert
            var exception = Assert.Throws<Exception>(action);
            Assert.Equal($"{nameof(Transaction.Description)} is required", exception.Message);
        }

        [Fact]
        public void TransactionWithLessThanZeroAmount_ThrowsException()
        {
            // Arrange
            var type = TransactionType.Deposit;
            var amount = -10;
            var description = "Deposit";
            
            // Act
            Action action = () => { _ = new Transaction(type, amount, description); };

            // Assert
            var exception = Assert.Throws<Exception>(action);
            Assert.Equal($"{nameof(Transaction.Amount)} should be greater than zero", exception.Message);

        }

        [Fact]
        public void TransactionWithRightParameters_GenerateInstance()
        {
            // Arrange
            var type = TransactionType.Deposit;
            var amount = 10;
            var description = "Deposit";

            // Act
            var transaction = new Transaction(type, amount, description);

            // Assert
            Assert.Equal(amount, transaction.Amount);
            Assert.Equal(description, transaction.Description);
            Assert.Equal(type, transaction.Type);
        }

    }
}