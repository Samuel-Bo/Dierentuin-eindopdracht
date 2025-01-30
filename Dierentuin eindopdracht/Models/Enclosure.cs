using System.ComponentModel.DataAnnotations;

namespace Dierentuin_eindopdracht.Models
{
    public class Enclosure
    {
        [Required]
        public string Id { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "an enclosure always has a Size")]
        public double Size { get; set; }

        //enums
        ZooEnums.Climate Climate { get; set; }
        ZooEnums.HabitatType Habitat { get; set; }
        ZooEnums.SecurityLevel SecurityLevel { get; set; }

        //navigation properties
        public ICollection<Animal> Animals { get; set; }
    }
}
