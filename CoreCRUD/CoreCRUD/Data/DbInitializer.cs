using CoreCRUD.Models;
using CoreCRUD.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCRUD.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CoreCRUDContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Trucks.
            if (context.Trucks.Any())
            {
                return;   // DB has been seeded
            }

            var cars = new Car[]
            {
                new Car{TireWear=0.60,HasTowStrap = true},
                new Car{TireWear=0.65,HasTowStrap = true},
                new Car{TireWear=0.70,HasTowStrap = true},
                new Car{TireWear=0.90,HasTowStrap = false}
            };

            context.Cars.AddRange(cars);
            context.SaveChanges();

            var trucks = new Truck[]
            {
                new Truck{LeftInches=1, HasTowStrap = true},
                new Truck{LeftInches=3, HasTowStrap = true},
                new Truck{LeftInches=4, HasTowStrap = true},
                new Truck{LeftInches=6, HasTowStrap = false},
            };

            context.Trucks.AddRange(trucks);
            context.SaveChanges();

        }
    }
    
}
