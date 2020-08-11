using CoreCRUD.BusImp;
using CoreCRUD.Data;
using CoreCRUD.Models;
using CoreCRUD.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCRUD.Service
{
    public class RaceTrackService : IRaceTrackService
    {
        private IRaceTrack _raceTrack;
        private readonly CoreCRUDContext _context;
        public RaceTrackService(CoreCRUDContext context, IRaceTrack raceTrack)
        {
            _context = context;
            _raceTrack = raceTrack;
        }
        public void AddVehicle<T>(T vehiclie) where T : Vehicle
        {
            if (_raceTrack == null)
                throw new Exception("Race Track has not been created!");
            if (_raceTrack.vehicles == null)
                _raceTrack.vehicles = new List<Vehicle>();

            if (Validate.ValidiateVehicle(_raceTrack,vehiclie))
                _raceTrack.vehicles.Add(vehiclie);
        }



        public RaceTrack CreateData(RaceTrack raceTrack)
        {
            _context.RaceTracks.Add(raceTrack);
            _context.SaveChanges();
            return raceTrack;
        }

        public void DeleteData(int id)
        {
            var entity = _context.RaceTracks.Find(id);
            _context.RaceTracks.Remove(entity);
            _context.SaveChanges();
        }

        public RaceTrack GetDataById(int id)
        {
            var raceTrack = _context.RaceTracks.Where(x => x.RaceTrackId == id).FirstOrDefault();
            return raceTrack;
        }

        public RaceTrack UpdateData(RaceTrack raceTrack)
        {
            try
            {
                var entity = _context.RaceTracks.SingleOrDefault(x => x.RaceTrackId.Equals(raceTrack.RaceTrackId));
                if (entity == null)
                    return null;
                entity.Name = raceTrack.Name;
                entity.vehicles = raceTrack.vehicles;
                _context.RaceTracks.Update(entity);
                _context.SaveChanges();
                return entity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<RaceTrack> GetAll()
        {
            return _context.RaceTracks.AsEnumerable<RaceTrack>();
        }
    }
}
