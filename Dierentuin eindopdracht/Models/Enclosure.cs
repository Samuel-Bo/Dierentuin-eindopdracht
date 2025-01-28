using System.ComponentModel.DataAnnotations;

namespace Dierentuin_eindopdracht.Models
{
    public class Enclosure
    {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Animals { get; set; }
        ZooEnums.Climate Climate { get; set; }
        ZooEnums.HabitatType Habitat { get; set; }
        ZooEnums.SecurityLevel SecurityLevel { get; set; }
        public double Size { get; set; }

    }
}
