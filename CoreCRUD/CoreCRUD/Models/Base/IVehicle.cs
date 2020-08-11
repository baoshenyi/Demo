using System;

namespace CoreCRUD.Models.Base
{
    public interface IVehicle
    {
        bool HasTowStrap { get; set; }
        bool PassInspection { get; }
    }
}