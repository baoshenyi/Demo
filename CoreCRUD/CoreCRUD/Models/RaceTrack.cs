using CoreCRUD.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCRUD.Models
{
    public class RaceTrack : IRaceTrack
    {
        [Key]
        public int RaceTrackId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public List<Vehicle> vehicles { get; set; }
    }
}
