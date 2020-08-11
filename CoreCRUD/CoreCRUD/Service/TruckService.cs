using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCRUD.Data;
using CoreCRUD.Models.Business;

namespace CoreCRUD.Service
{
    public class TruckService : ITruckService
    {
        private readonly CoreCRUDContext _context;
        public TruckService(CoreCRUDContext context)
        {
            _context = context;
        }


        public Truck GetDataById(int id)
        {
            var truck = _context.Trucks.Where(x => x.Id == id).FirstOrDefault();
            return truck;
        }

        public Truck CreateData(Truck truck)
        {
            _context.Trucks.Add(truck);
            _context.SaveChanges();
            return truck;
        }

        public Truck UpdateData(Truck truck)
        {
            var entity = _context.Trucks.SingleOrDefault(x => x.Id.Equals(truck.Id));
            entity.HasTowStrap = truck.HasTowStrap;
            entity.LeftInches = truck.LeftInches;
            _context.Trucks.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void DeleteData(int id)
        {
            var entity = _context.Trucks.Find(id);
            _context.Trucks.Remove(entity);
            _context.SaveChanges();

        }

        public IEnumerable<Truck> GetAll()
        {
            return _context.Trucks.AsEnumerable<Truck>();
        }
    }
}
