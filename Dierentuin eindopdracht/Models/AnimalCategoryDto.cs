using System.ComponentModel.DataAnnotations;

namespace Dierentuin_eindopdracht.Models
{
    public class AnimalCategoryDto
    {
        [Required(ErrorMessage ="a category must contain a name")]
        public string Name { get; set; }
        public ICollection<int> ?SelectedAnimalIds { get; set; }
    }
}
