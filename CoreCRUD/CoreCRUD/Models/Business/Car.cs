using CoreCRUD.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreCRUD.Models.Business
{
    public class Car : Vehicle, ICar
    {
        [Required]
        //Less than 85% tire wear
        public double TireWear { get; set; } = 0.0;
        [Required]
        public override bool PassInspection
        {
            get
            {
                if (HasTowStrap && TireWear <= 0.85) 
                    return true;
                return false;

            }
        }
    }
}
