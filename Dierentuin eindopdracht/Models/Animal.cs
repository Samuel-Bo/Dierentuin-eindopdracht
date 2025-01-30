using System.ComponentModel.DataAnnotations;

namespace Dierentuin_eindopdracht.Models
{
    public class Animal
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "every animal has a name")]
        public string Name { get; set; }

        public string Species { get; set; }

        public string Category { get; set; }

        public string Prey { get; set; }

        public double SpaceRequirement { get; set; }

        //enums
        public ZooEnums.Size Size { get; set; }
        public ZooEnums.DietaryClass DietaryClass { get; set; }
        public ZooEnums.ActivityPattern ActivityPattern { get; set; }
        ZooEnums.SecurityLevel SecurityRequiremnt { get; set; }

        //navigation properties
        [Required(ErrorMessage = "sorry, we don't want animals wandering around the zoo casually")]
        public Enclosure Enclosure { get; set; }


    }
}
