using System.ComponentModel.DataAnnotations;

namespace Dierentuin_eindopdracht.Models
{
    public class AnimalDto
    {
        [Required(ErrorMessage = "every animal has a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "every animal has a species")]
        public string Species { get; set; }

        public string ?Prey { get; set; }

        [Required(ErrorMessage = "every animal has a SpaceRequirement")]
        public double SpaceRequirement { get; set; }

        [Required(ErrorMessage = "every animal has a FeedingTime")]
        public string FeedingTime { get; set; }

        [Required(ErrorMessage = "every animal has a time they wake up")]
        public TimeSpan Arise { get; set; }

        [Required(ErrorMessage = "every animal has a time they go to bed")]
        public TimeSpan BedTime { get; set; }

        //enums
        [Required(ErrorMessage = "every animal has a size")]
        public ZooEnums.Size Size { get; set; }

        [Required(ErrorMessage = "every animal has a Dietaryclass")]
        public ZooEnums.DietaryClass DietaryClass { get; set; }

        [Required(ErrorMessage = "every animal has an ActivityPattern")]
        public ZooEnums.ActivityPattern ActivityPattern { get; set; }

        [Required(ErrorMessage = "every animal has a SecurityRequirement")]
        public ZooEnums.SecurityLevel SecurityRequirement { get; set; }
        public int? EnclosureId { get; set; } //f-key
        public int? AnimalCategoryId { get; set; } // f-key 
    }
}
