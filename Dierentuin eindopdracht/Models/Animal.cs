using System.ComponentModel.DataAnnotations;

namespace Dierentuin_eindopdracht.Models
{
    public class Animal
    {
        [Required]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "every animal has a name")]
        public string Name { get; set; }

        public string Species { get; set; }

        public string Prey { get; set; }

        public double SpaceRequirement { get; set; }
        public TimeSpan FeedingTime { get; set; }
        public TimeSpan Arise { get; set; }
        public TimeSpan BedTime { get; set; }

        //enums
        public ZooEnums.Size Size { get; set; }
        public ZooEnums.DietaryClass DietaryClass { get; set; }
        public ZooEnums.ActivityPattern ActivityPattern { get; set; }
        public ZooEnums.SecurityLevel SecurityRequirment { get; set; }

        //navigation properties
        public int EnclosureId { get; set; } //f-key
        public int CategoryId  { get; set; }// f-key
        public int ZooId { get; set; } // f-key
        public Enclosure Enclosure { get; set; } = null;
        public Category Category { get; set; } = null;
        public Zoo Zoo { get; set; }


    }
}
