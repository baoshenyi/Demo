using CoreCRUD.Models;
using CoreCRUD.Models.Business;
using Microsoft.EntityFrameworkCore;

namespace CoreCRUD.Data
{
    public interface ICoreCRUDContext
    {
        DbSet<Car> Cars { get; set; }
        DbSet<RaceTrack> RaceTracks { get; set; }
        DbSet<Truck> Trucks { get; set; }
    }
}