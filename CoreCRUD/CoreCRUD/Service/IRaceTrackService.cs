using CoreCRUD.Models;
using CoreCRUD.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCRUD.Service
{
    public interface IRaceTrackService
    {
        IEnumerable<RaceTrack> GetAll();
        RaceTrack GetDataById(int id);
        RaceTrack CreateData(RaceTrack raceTrack);
        RaceTrack UpdateData(RaceTrack raceTrack);
        void DeleteData(int id);

        void AddVehicle<T>(T vehiclie) where T : Vehicle;
    }
}
