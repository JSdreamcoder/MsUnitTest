using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace VehicleTest
{
    [TestClass]
    public class UnitTest1
    {
        private VehicleTracker testTracker;
        private Vehicle vehicle1;
        private Vehicle vehicle2;
        private Vehicle vehicle3;
        private Vehicle vehicle4;
        private int capacity = 3;
        [TestInitialize]
        public void TestInitialize()
        {
            vehicle1 = new Vehicle("aaa", false);
            vehicle2 = new Vehicle("bbb", true);
            vehicle3 = new Vehicle("ccc", true);
            vehicle4 = new Vehicle("ddd", true);
            testTracker = new VehicleTracker(capacity, "Winnipeg");
        }
        // GenerateSlots Function
        [TestMethod]
        public void checkIfGenerateSlotCorrectly()
        {
            //Arrange
            var expectedNumberofSlot = capacity;
            int Slotavailable = testTracker.VehicleList.Where(v => v.Value != null).Count();
            //Assert
            Assert.AreEqual(expectedNumberofSlot,testTracker.VehicleList.Count);
        }
        [TestMethod]
        public void LessThan1CapacityinGenerate()
        {
            // Arrange
            var capacity1 = 0;
            var capacity2 = -1;
            var address = "winnipeg";

            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var testTracker = new VehicleTracker(capacity1, address);
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                var testTracker = new VehicleTracker(capacity2, address);
            });
        }
        //AddVehicle Function
        [TestMethod]
        public void AddVehicletoSlot()
        {
            //Arrange
            var Expectedslotfilled = 1;
            
            //Act
            testTracker.AddVehicle(vehicle1);
            int slotfilled = testTracker.VehicleList.Where((v) => v.Value != null).Count();
            //Assert
            Assert.AreEqual(Expectedslotfilled, slotfilled);

        }
        [TestMethod]
        public void OutOfRangeExceptipnInAddVehicle()
        {
            //Act and Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                testTracker.AddVehicle(vehicle1);
                testTracker.AddVehicle(vehicle2);
                testTracker.AddVehicle(vehicle3); // full
                testTracker.AddVehicle(vehicle4); // expected throw exception
            });
        }
        //RemoveVehicle Function
        [TestMethod]
        public void TestRemoveVehiclebyLicence()
        {
            //Arrange 
            testTracker.AddVehicle(vehicle1);
            var licenceOfVehicle1 = vehicle1.Licence;

            //Act
            testTracker.RemoveVehicle(licenceOfVehicle1);

            //Arrange
            Assert.IsFalse(testTracker.VehicleList.Values.Contains(vehicle1));
        }
        [TestMethod]
        public void InvalidlicenceInRemoveVehicle()
        {
            //Arrange
            var invalidLicence = "zzz";

            //Act Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                testTracker.RemoveVehicle(invalidLicence);
            });
        }
        [TestMethod]
        public void InvalidSlotNumberToRemoveVehicle()
        {
            //slot number > capacity
            var slotnumber1 = capacity + 1;
            //slot number <= 0 
            var slotnumber2 = 0;
            //VehicleList[slotnumber] == null
            var slotnumber3 = 1;

            //Act & Assert
            Assert.IsFalse(testTracker.RemoveVehicle(slotnumber1));
            Assert.IsFalse(testTracker.RemoveVehicle(slotnumber2));
            Assert.IsFalse(testTracker.RemoveVehicle(slotnumber3));
        }

        [TestMethod]
        public void checkIfRemoveVehicleRun()
        {
            //Arrange
            testTracker.AddVehicle(vehicle1);

            //Act &Assert
            Assert.IsTrue(testTracker.RemoveVehicle(1));
        }

        //ParkedPassholders
        [TestMethod]
        public void checkParkedPassholders()
        {
            var expectedParkedPasshoder = 1;
            testTracker.AddVehicle(vehicle1);
            testTracker.AddVehicle(vehicle2);
            
            Assert.AreEqual(expectedParkedPasshoder, testTracker.ParkedPassholders().Count());
        }

        //PasshoderPercentage
        [TestMethod]
        public void checkPasshoderPercentage()
        {
            //Arrange
            int expectedPercentage = 50;
            testTracker.AddVehicle(vehicle1);
            testTracker.AddVehicle(vehicle2);

            //Act
            int num = testTracker.ParkedPassholders().Count();
            int percentage = testTracker.PassholderPercentage();

            //Assert
            Assert.AreEqual(percentage, expectedPercentage);
        }
    }
}