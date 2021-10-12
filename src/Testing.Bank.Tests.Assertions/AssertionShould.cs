using System;
using System.Collections.Generic;
using Xunit;

namespace Testing.Bank.Tests.Assertions
{
    public class AssertionShould
    {
        /*
         * Pending: 
         * Empty
         * NotEmpty
         * True
         * False
         * Null
         * NotNull
         * Throws<T>
         */

        [Fact]
        public void Equal()
        {
            // Arrange
            var message = "Hello Morty!";

            // Act
            
            // Assert
            Assert.Equal("Hello Morty!", message);
        }

        [Fact]
        public void NotEqual()
        {
            // Arrange
            var message = "Hello Morty!";

            // Act

            // Assert
            Assert.NotEqual("By Rick!", message);
        }

        [Fact]
        public void Same()
        {
            // Arrange
            var singleton = SingletonFactory.GetInstance();

            // Act

            // Assert
            Assert.Same(singleton, SingletonFactory.GetInstance());
        }

        [Fact]
        public void NotSame()
        {
            // Arrange
            var singleton = SingletonFactory.GetInstance();

            // Act

            // Assert
            Assert.NotSame(singleton, SingletonFactory.GetNewInstance());
        }

        [Fact]
        public void Contains()
        {
            // Arrange
            var persons = new List<string>() { "Rick", "Morty", "Summer", "Beth", "Jerry"};

            // Act

            // Assert
            Assert.Contains("Morty", persons);
        }

        [Fact]
        public void NotContains()
        {
            // Arrange
            var persons = new List<string>() { "Rick", "Morty", "Summer", "Beth", "Jerry" };

            // Act

            // Assert
            Assert.DoesNotContain("Squanchy", persons);
        }

        [Fact]
        public void InRange()
        {
            // Arrange
            var @value = 10;

            // Act

            // Assert
            Assert.InRange(@value, int.MinValue, int.MaxValue);
        }


        [Fact]
        public void NotInRange()
        {
            // Arrange
            var @value = 10;

            // Act

            // Assert
            Assert.NotInRange(@value, 20, 30);
        }

        [Fact]
        public void IsAssignableFrom()
        {
            // Arrange
            var singleton = SingletonFactory.GetInstance();

            // Act

            // Assert
            Assert.IsAssignableFrom(typeof(ISingletonFactory), singleton);
        }

        [Fact]
        public void IsType()
        {
            // Arrange
            var singleton = SingletonFactory.GetInstance();

            // Act

            // Assert
            Assert.IsType(typeof(SingletonFactory), singleton);
        }
    }
}
