using System.ComponentModel.DataAnnotations;

namespace Dierentuin_eindopdracht.Models
{
    public class Enclosure
    {
        public int EnclosureId { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "an enclosure always has a Size")]
        public double Size { get; set; }

        //enums
        public ZooEnums.Climate Climate { get; set; }
        public ZooEnums.HabitatType Habitat { get; set; }
        public ZooEnums.SecurityLevel SecurityLevel { get; set; }

        //navigation properties
        public ICollection<Animal> ?Animals { get; set; }
        public int ZooId { get; set; } //f-key
        public Zoo Zoo { get; set; }
    }
}

