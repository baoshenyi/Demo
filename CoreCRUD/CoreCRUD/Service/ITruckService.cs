using CoreCRUD.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCRUD.Service
{
    public interface ITruckService
    {
        IEnumerable<Truck> GetAll();
        Truck GetDataById(int id);
        Truck CreateData(Truck truck);
        Truck UpdateData(Truck truck);
        void DeleteData(int id);
    }
}
