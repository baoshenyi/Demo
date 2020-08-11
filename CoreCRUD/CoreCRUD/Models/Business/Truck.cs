using CoreCRUD.Models.Base;
using System.ComponentModel.DataAnnotations;


namespace CoreCRUD.Models.Business
{
    public class Truck : Vehicle, ITruck
    {
        //Flunt API or Data Anotation could be used for validatoin
        [Required]
        //Not lifted more than 5 inches
        public int LeftInches { get; set; } = 0;
        [Required]
        public override bool PassInspection
        {
            get
            {
                if (HasTowStrap && LeftInches <= 5) 
                    return true;
                return false;
                
            }
        }
    }
}
