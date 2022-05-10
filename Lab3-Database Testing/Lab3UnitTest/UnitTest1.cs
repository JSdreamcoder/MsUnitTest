using Lab3_Database_Testing.Data;
using Lab3_Database_Testing.Data.BLL;
using Lab3_Database_Testing.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Lab3UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Mock<Irepository<ParkingSpace>> ParkingSapceMRepo;
        Mock<Irepository<Pass>> PassMRepo;
        PassBLL PassBl;
        ParkingBLL ParkingSpaceBl;

        [TestInitialize]
        public void InitializedTest()
        {
            ParkingSapceMRepo = new Mock<Irepository<ParkingSpace>>();
            PassMRepo = new Mock<Irepository<Pass>>();
            

            PassBl = new PassBLL(PassMRepo.Object);
            ParkingSpaceBl = new ParkingBLL(ParkingSapceMRepo.Object);
        }
        [TestMethod]
        public void CreatePasswithPurchaseLessThan3letterThrowException()
        {
            string purchase = "J";
            var newPass = new Pass(purchase);

           // PassMRepo.Setup(r => r.Create(newPass));

            Assert.ThrowsException<Exception>(() => PassBl.CreatePass(newPass));
        }

        [TestMethod]
        public void CreateParkingSpacewithNumberLessThan1ThrowExecption()
        {
            //Arrange
            int number = 0;
            var newparkingSpace = new ParkingSpace(number);
            Assert.ThrowsException<Exception>(() => ParkingSpaceBl.CreateParkingSpace(newparkingSpace));
                      
        }
    }   
}