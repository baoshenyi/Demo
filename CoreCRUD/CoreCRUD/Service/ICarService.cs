using CoreCRUD.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCRUD.Service
{
    public interface ICarService
    {
        IEnumerable<Car> GetAll();
        Car GetDataById(int id);
        Car CreateData(Car car);
        Car UpdateData(Car car);
        void DeleteData(int id);
    }
}
