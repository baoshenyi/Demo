using System.Collections.Generic;
using CoreCRUD.Models.Base;

namespace CoreCRUD.Models
{
    public interface IRaceTrack
    {
        string Name { get; set; }
        int RaceTrackId { get; set; }
        List<Vehicle> vehicles { get; set; }
    }
}