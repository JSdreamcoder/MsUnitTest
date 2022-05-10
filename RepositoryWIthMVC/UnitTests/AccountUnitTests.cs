using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepositoryWIthMVC.Data;
using RepositoryWIthMVC.Data.BLL;
using RepositoryWIthMVC.Models;
using System;

namespace UnitTests
{
    [TestClass]
    public class AccountUnitTests
    {
        Mock<IRepository<Account>> repoMock;
        AccountBusinessLogic accountBl;
        
        [TestInitialize]
        public void InitialLizeTest()
        {
            repoMock = new Mock<IRepository<Account>>();


            repoMock.Setup(r => r.Get(It.Is<int>(i => i == 1))).Returns(new Account
            {
                Id = 1,
                
                Balance = 123.45,
                IsActive = true,
                Name = "textAccount"
            }); ;
            //repoMock.Setup(r => r.Get(It.IsAny<Func<Account, bool>>()));

            accountBl = new AccountBusinessLogic(repoMock.Object);
        }
        //Get all active accounts
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(123,45, accountBl.GetBalance(1));
        }

        [TestMethod]
        public void GetBalanceWithNullReferenceIdReturnsException()
        {
            Assert.ThrowsException<Exception>(() => accountBl.GetBalance(2));
        }

        // SetAccountToInactive should change an account's "IsActive" to false
        // If an account is already inactive, throw an exception
        // it should also throw an exception if the return is null

        [TestMethod]
        public void SetAccountToInactiveMakesIsActiveFalse()
        {
            accountBl.SetAccountToInactive(1);
           // repoMock.Verify(x => x.Get(It.Is<int>(i=>i==1)).IsActive == false);
            Assert.AreEqual(false, repoMock.Object.Get(1).IsActive);
        }

        [TestMethod]
        public void SetAccountToInactiveThrowExceptionIfalreadyIactive()
        {
            accountBl.SetAccountToInactive(1);

            Assert.ThrowsException<Exception>(() => accountBl.SetAccountToInactive(1));
        }

        [TestMethod]
        public void SetAccountToInactiveThrowExceptionOnNullIdReference()
        {
            Assert.ThrowsException<Exception>(() => accountBl.SetAccountToInactive(2));
        }
    }
}