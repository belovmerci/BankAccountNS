using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankAccountNS;

namespace BankAccountNS.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Test", 100.00);

            // Act
            account.Debit(25.50);

            // Assert
            Assert.AreEqual(74.50, account.Balance, 0.001, "Количество денег на счёте не было обновлено корректно.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Test", 100.00);

            // Act
            account.Debit(-5.00);

            // Assert
            // Expecting an ArgumentOutOfRangeException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_ExceedsBalance_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Test", 50.00);

            // Act
            account.Debit(75.00);

            // Assert
            // Expecting an ArgumentOutOfRangeException
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Test", 100.00);

            // Act
            account.Credit(30.50);

            // Assert
            Assert.AreEqual(130.50, account.Balance, 0.001, "Количество кред. линии не было обновлено корректно.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Credit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Test", 100.00);

            // Act
            account.Credit(-5.00);

            // Assert
            // Expecting an ArgumentOutOfRangeException
        }

        [TestMethod]
        public void Main_Method_CorrectlyUpdatesBalance()
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Bryan Walton", 11.99);

            // Act
            account.Credit(5.77);
            account.Debit(11.22);

            // Assert
            Assert.AreEqual(6.54, account.Balance, 0.001, "Главный метод не обновил баланс корректно.");
        }
    }
}

