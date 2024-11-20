using Xunit;
using System;
using BankAccount;

namespace BankAccount_TestUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Credit_IncreasesBalance()
        {
            var account = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);
            account.Credit(50);
            Assert.Equal(150, account.Balance);
        }

        [Fact]
        public void Debit_DecreasesBalance()
        {
            var account = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);
            account.Debit(50);
            Assert.Equal(50, account.Balance);
        }

        [Fact]
        public void Debit_ThrowsException_WhenInsufficientBalance()
        {
            var account = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<Exception>(() => account.Debit(150));
        }

        [Fact]
        public void Transfer_DecreasesBalanceOfFromAccount()
        {
            var fromAccount = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);
            var toAccount = new BankAccount("456", 50, "Jane Doe", "Savings", DateTime.Now);
            fromAccount.Transfer(toAccount, 50);
            Assert.Equal(50, fromAccount.Balance);
        }

        [Fact]
        public void Transfer_IncreasesBalanceOfToAccount()
        {
            var fromAccount = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);
            var toAccount = new BankAccount("456", 50, "Jane Doe", "Savings", DateTime.Now);
            fromAccount.Transfer(toAccount, 50);
            Assert.Equal(100, toAccount.Balance);
        }

        [Fact]
        public void Transfer_ThrowsException_WhenInsufficientBalance()
        {
            var fromAccount = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);
            var toAccount = new BankAccount("456", 50, "Jane Doe", "Savings", DateTime.Now);
            Assert.Throws<Exception>(() => fromAccount.Transfer(toAccount, 150));
        }

        [Fact]
        public void Transfer_ThrowsException_WhenAmountExceedsLimitForDifferentOwners()
        {
            var fromAccount = new BankAccount("123", 1000, "John Doe", "Savings", DateTime.Now);
            var toAccount = new BankAccount("456", 500, "Jane Doe", "Savings", DateTime.Now);
            Assert.Throws<Exception>(() => fromAccount.Transfer(toAccount, 600));
        }

        [Fact]
        public void GetBalance_ReturnsCorrectBalance()
        {
            var account = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Equal(100, account.GetBalance());
        }

        [Fact]
        public void CalculateInterest_ReturnsCorrectInterest()
        {
            var account = new BankAccount("123", 1000, "John Doe", "Savings", DateTime.Now);
            double interestRate = 0.05;
            double expectedInterest = 1000 * interestRate;
            Assert.Equal(expectedInterest, account.CalculateInterest(interestRate));
        }

        [Fact]
        public void Credit_AllowsMultipleCredits()
        {
            var account = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);
            account.Credit(50);
            account.Credit(25);
            Assert.Equal(175, account.Balance);
        }

        [Fact]
        public void Debit_AllowsMultipleDebits()
        {
            var account = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);
            account.Debit(30);
            account.Debit(20);
            Assert.Equal(50, account.Balance);
        }

        [Fact]
        public void Transfer_AllowsMultipleTransfers()
        {
            var fromAccount = new BankAccount("123", 200, "John Doe", "Savings", DateTime.Now);
            var toAccount = new BankAccount("456", 50, "Jane Doe", "Savings", DateTime.Now);
            fromAccount.Transfer(toAccount, 50);
            fromAccount.Transfer(toAccount, 50);
            Assert.Equal(100, fromAccount.Balance);
            Assert.Equal(150, toAccount.Balance);
        }
    }
}
