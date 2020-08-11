using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using CoreCRUD.Data;
using Moq;
using Microsoft.EntityFrameworkCore;
using CoreCRUD.Models;
using CoreCRUD.Models.Base;
using CoreCRUD.Models.Business;

namespace CoreCRUD.Service.Tests
{
    [TestClass()]
    public class RaceTrackServiceTests
    {
        private CoreCRUDContext _context;
        private RaceTrack raceTrack1;
        private readonly Truck truck = new Truck() { Id = 1, HasTowStrap = true, LeftInches = 1 };

        [TestInitialize]
        public void Initialize()
        {
            try
            {
                var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

                var options = new DbContextOptionsBuilder<CoreCRUDContext>()
                                .UseInMemoryDatabase(databaseName: myDatabaseName)
                                .Options;
                _context = new CoreCRUDContext(options);
                raceTrack1 = new RaceTrack
                {
                    RaceTrackId = 1,
                    Name = "track1",
                    vehicles = new List<Vehicle>()
                };
                _context.RaceTracks.AddRange(
                    raceTrack1
                );
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [TestMethod()]
        public void AddVehicleTest()
        {

            new RaceTrackService(_context, raceTrack1).AddVehicle<Truck>(this.truck);
            var addedTruck = _context.RaceTracks.Find(raceTrack1.RaceTrackId).vehicles.FindAll(x => x.HasTowStrap = true);

            Assert.IsNotNull(addedTruck);
            Assert.IsTrue(addedTruck.Count == 1);
            Assert.AreEqual(truck, addedTruck[0]);
        }

        [TestMethod]
        public void GetDataByIdTest()
        {
            var result = new RaceTrackService(_context, raceTrack1).GetDataById(raceTrack1.RaceTrackId);
            Assert.IsNotNull(result);
            Assert.AreEqual(result,raceTrack1);
        }

        [TestMethod]
        public void CreateDataTest()
        {
            var raceTrack2 = new RaceTrack
            {
                RaceTrackId = 2,
                Name = "track2",
                vehicles = new List<Vehicle>()
            };

            var addedTrack = new RaceTrackService(_context, raceTrack1).CreateData(raceTrack2);

            Assert.IsNotNull(addedTrack);
            Assert.AreEqual(raceTrack2, addedTrack);
        }

        [TestMethod]
        public void DeleteDataTest()
        {
            new RaceTrackService(_context, raceTrack1).DeleteData(raceTrack1.RaceTrackId);
            var deletedTrack = _context.RaceTracks.Find(raceTrack1.RaceTrackId);

            Assert.IsNull(deletedTrack);
        }

        [TestMethod]
        public void UpdateDataTest()
        {
            var track = new RaceTrack
            {
                RaceTrackId = 1,
                Name = "track2",
                vehicles = new List<Vehicle>()
            };
            var result = new RaceTrackService(_context, raceTrack1).UpdateData(track);

            Assert.AreEqual(raceTrack1.Name, result.Name);


            track.RaceTrackId = 2;
            var result2 = new RaceTrackService(_context, raceTrack1).UpdateData(track);

            Assert.IsNull(result2);
        }


        [TestMethod]
        public void GetAllTest()
        {
            IEnumerable<RaceTrack> result = new RaceTrackService(_context, raceTrack1).GetAll();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Any(x => x.RaceTrackId.Equals(raceTrack1.RaceTrackId)));
        }
    }
}