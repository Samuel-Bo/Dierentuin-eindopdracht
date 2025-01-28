using System.ComponentModel.DataAnnotations;

namespace Dierentuin_eindopdracht.Models
{
    public class Animal
    {
        [Required]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Category { get; set; }
        public ZooEnums.Size Size { get; set; }
        public ZooEnums.DietaryClass DietaryClass { get; set; }
        public ZooEnums.ActivityPattern ActivityPattern { get; set; }
        public string Prey { get; set; }
        public string Enclosure { get; set; }
        public double SpaceRequirement { get; set; }
        ZooEnums.SecurityLevel SecurityRequiremnt { get; set; }


    }
}
