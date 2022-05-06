using DALBank.BLL;
using DALBank.DAL;
using DALBank.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dalbanktest
{
    [TestClass]
    public class UnitTest1
    {
        private AccountBusinessLogic abl;
        private CustomerBusinessLogic cbl;
        private List<Account> allAccount;
        [TestInitialize]
        public void Initialize()
        {

            Mock<AccountRepository> mockRepo = new Mock<AccountRepository>();
            Mock<CustomerRepository> mockCustomerRepo = new Mock<CustomerRepository>();
            Account mockAccount1 = new Account { Id = 1, Name = "Checking", Balance = 123.45, IsActive = true,CustomerId =1 };
            Account mockAccount2 = new Account { Id = 2, Name = "Savings", Balance = 2131234.23, IsActive = true, CustomerId = 1 };
            Account mockAccount3 = new Account { Id = 3, Name = "TFSA", Balance = -12, IsActive = true, CustomerId = 1 };

            allAccount = new List<Account> { mockAccount1 , mockAccount2,mockAccount3 };

            // testing double
            mockRepo.Setup(repo => repo.GetAccounts()).Returns(allAccount);

            //replace Delete
            mockRepo.Setup(repo=> repo.DeleteAccount(It.Is<Account>(a=>a.CustomerId ==1))).Callback(()=>allAccount.Remove(mockAccount1));


            mockRepo.Setup(repo => repo.GetAccountById(It.Is<int>(i => i == 1))).Returns(mockAccount1);
            mockRepo.Setup(repo => repo.GetAccountById(It.Is<int>(i => i == 2))).Returns(mockAccount2);
            mockRepo.Setup(repo => repo.GetAccountById(It.Is<int>(i => i == 3))).Returns(mockAccount3);

            abl = new AccountBusinessLogic(mockRepo.Object);
            cbl = new CustomerBusinessLogic(mockCustomerRepo.Object);
        }
        [TestMethod]
        public void GetBalanceTest()
        {
            Assert.AreEqual(123.45, abl.GetBalance(1));
        }

        [TestMethod]
        public void GetAllBalancesReturnsSumOfActiveAccountBalance()
        {
            double expectedSum = allAccount.Sum(a=> a.Balance);
            
            Assert.AreEqual(expectedSum, abl.GetAllAccountOfCustomer(1).Sum(a=>a.Balance));

        }

        [TestMethod]
        public void MakeAllAccountInactive()
        {
            //Arrange
            List<Account> expectedResult = new List<Account>();
            foreach (var account in allAccount)
            {
                expectedResult.Add(account);
            }
            foreach (var account in expectedResult)
            {
                account.IsActive = false;
            }

            //Active
            cbl.CloseAllAccount(1,abl);


            int expectedCount = expectedResult.Where(a => a.IsActive == false).Count(); //3
            int ActualCount = allAccount.Where(a => a.IsActive == false).Count(); //3

            Assert.AreEqual(expectedCount,ActualCount );
        }

        [TestMethod]
        public void TestWithdraw()
        {
            double testWithdrawMoney = 23.45;
            double expectedBalance = allAccount[0].Balance - testWithdrawMoney;

            abl.Withdraw(1, testWithdrawMoney);
           
            Assert.AreEqual(expectedBalance,allAccount[0].Balance);

        }

        [TestMethod]
        public void TestDeposit()
        {
            double testDepositeMoney = 1000;
            double expectedBalance = allAccount[0].Balance + testDepositeMoney;

            abl.Deposit(1, testDepositeMoney);
           
            Assert.AreEqual(expectedBalance, allAccount[0].Balance);

        }



        [TestMethod]
        public void TestDepositMoneyisUnder0()
        {
            double testDepositeMoney = -100;

            Assert.ThrowsException<ArgumentException>(() =>
              abl.Deposit(1, testDepositeMoney)
            );

        }
    }
}