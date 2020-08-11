using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCRUD.Data;
using CoreCRUD.Models.Business;

namespace CoreCRUD.Service
{
    public class CarService : ICarService
    {
        private readonly CoreCRUDContext _context;
        public CarService(CoreCRUDContext context)
        {
            _context = context;
        }
        public Car CreateData(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return car;
        }

        public void DeleteData(int id)
        {
            var entity = _context.Cars.Find(id);
            _context.Cars.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.AsEnumerable<Car>();
        }

        public Car GetDataById(int id)
        {
            var car = _context.Cars.Where(x => x.Id == id).FirstOrDefault();
            return car;
        }

        public Car UpdateData(Car car)
        {
            var entity = _context.Cars.SingleOrDefault(x => x.Id.Equals(car.Id));
            entity.HasTowStrap = car.HasTowStrap;
            entity.TireWear = car.TireWear;
            _context.Cars.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
