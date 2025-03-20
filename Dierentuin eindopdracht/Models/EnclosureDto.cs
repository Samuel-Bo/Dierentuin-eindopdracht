using Dierentuin_eindopdracht.Services;
using System.ComponentModel.DataAnnotations;

namespace Dierentuin_eindopdracht.Models
{
    public class EnclosureDto // the Dto model for values that will be entered by the user for creating a new enclosure
    {
        [MaxLength(10)]

        [Required(ErrorMessage = "An enclosure needs a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "an enclosure always has a Size")]
        public double Size { get; set; }

        //enums
        [Required(ErrorMessage = "an enclosure needs a climate")]
        public ZooEnums.Climate Climate { get; set; }

        [Required(ErrorMessage = "an enclosure needs a habitat type")]
        public ZooEnums.HabitatType Habitat { get; set; }

        [Required(ErrorMessage = "an enclosure needs a SecurityLevel")]
        public ZooEnums.SecurityLevel SecurityLevel { get; set; }
        public ICollection<Animal> ?Animals { get; set; }
    }
}
