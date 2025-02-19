using System.ComponentModel.DataAnnotations;

namespace Dierentuin_eindopdracht.Models
{
    public class Zoo
    {
        [Required]
        public int ZooId { get; set; }
        public string Name { get; set; }

        //navigation properties
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
        public ICollection<Enclosure> Enclosures { get; set;} = new List<Enclosure>();
    }
}
