using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace MsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Account testAccount;
        private double initialbalance = 235.75;
        [TestInitialize]
        public void TestInitialize()
        {
            testAccount = new Account();
            testAccount.balance = 235.75;
        }
        [TestMethod]
        public void WithdrawalSubtractsFromBalance()
        {
            //Arrange
            
            double withdrawalAmout = 122.50;
            double expectedFinalBalance = testAccount.balance - withdrawalAmout;

            
            

            //Act
            testAccount.Withdraw(withdrawalAmout);

            // Assert
            Assert.AreEqual(expectedFinalBalance,testAccount.balance);

        }
        [TestMethod]
        public void AccountWithdrawalThrowsErrorOnNegativeInput()
        {
            // Triple-A Method (AAA Method): Arrange, Act, Assert
            //Arrange
            double withdrawalAmount = -2;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
                testAccount.Withdraw(withdrawalAmount)
            );
        }

        [TestMethod]
        public void DepositAddsToBalance()
        {
            //arrange
            double amount = 9213.32;

            // act
            testAccount.Deposit(amount);

            //assert
            Assert.AreEqual(amount+initialbalance, testAccount.balance);
        }

        [TestMethod]
        public void DepositZeroOrLessThrowArgumentException()
        {
            //act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                testAccount.Deposit(0);
            });

            Assert.ThrowsException<ArgumentException>(() =>
               testAccount.Deposit(-12));
        }
    }
}