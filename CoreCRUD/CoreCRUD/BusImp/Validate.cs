using CoreCRUD.Models;
using CoreCRUD.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCRUD.BusImp
{
    public static class Validate
    {
        public static bool ValidiateVehicle<T>(IRaceTrack _raceTrack, T vehiclie) where T : Vehicle
        {
            return _raceTrack != null &&
                            _raceTrack.vehicles.Count < Constraint.maxNumberVehiclesOnRaceTrack &&
                            vehiclie.PassInspection;
        }
    }
}
