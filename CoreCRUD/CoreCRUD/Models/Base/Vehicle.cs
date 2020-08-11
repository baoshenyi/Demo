using System.ComponentModel.DataAnnotations;

namespace CoreCRUD.Models.Base
{
    public abstract class Vehicle : IVehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool HasTowStrap { get; set; } = true;
        public virtual bool PassInspection { get; }
    }
}
