using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreCRUD.BusImp;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using CoreCRUD.Models;
using CoreCRUD.Models.Base;
using CoreCRUD.Models.Business;

namespace CoreCRUD.BusImp.Tests
{
    [TestClass()]
    public class ValidateTests
    {
        private Mock<IRaceTrack> _mockRaceTrackFive;
        private Mock<IRaceTrack> _mockRaceTrackFour;
        [TestInitialize]
        public void Initialize()
        {
            try
            {
                _mockRaceTrackFive = new Mock<IRaceTrack>();
                //IRaceTrack rt = new RaceTrack();
                List<Vehicle> v = new List<Vehicle>()
                {
                    new Truck(){Id =1, HasTowStrap = true, LeftInches =1},
                    new Truck(){Id =2, HasTowStrap = true, LeftInches =2},
                    new Truck(){Id =3, HasTowStrap = true, LeftInches =3},
                    new Truck(){Id =4, HasTowStrap = true, LeftInches = 4},
                    new Car(){Id =5, HasTowStrap = true, TireWear = 0.60}
                };
                _mockRaceTrackFive.Setup(x => x.vehicles).Returns(v);

                _mockRaceTrackFour = new Mock<IRaceTrack>();
                List<Vehicle> vFour = new List<Vehicle>()
                {
                    new Truck(){Id =1, HasTowStrap = true, LeftInches =1},
                    new Truck(){Id =2, HasTowStrap = true, LeftInches =2},
                    new Truck(){Id =3, HasTowStrap = true, LeftInches =3},
                    new Car(){Id =5, HasTowStrap = true, TireWear = 0.60}
                };
                _mockRaceTrackFour.Setup(x => x.vehicles).Returns(vFour);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod()]
        [TestCategory(nameof(Truck)+"-UnitTest")]
        public void ValidiateVehicle_False_MoreThanFiveVehiclie_Test()
        {
            var truck1 = new Truck() { Id = 1, HasTowStrap = true, LeftInches = 1 };
            var result = Validate.ValidiateVehicle(_mockRaceTrackFive.Object, truck1);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ValidiateVehicle_False_TruckInspection_Test()
        {
            var name = $"{nameof(Truck)} -UnitTest";
            var name1 = nameof(Truck) + "-UnitTest";
            var truck = new Truck() { Id = 1, HasTowStrap = true, LeftInches = 6 };
            var result = Validate.ValidiateVehicle(_mockRaceTrackFour.Object, truck);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ValidiateVehicle_False_CarInspection_Test()
        {
            var car = new Car() { Id = 1, HasTowStrap = true,TireWear = 0.95 };
            var result = Validate.ValidiateVehicle(_mockRaceTrackFour.Object, car);
            Assert.IsFalse(result);
        }
    }
}