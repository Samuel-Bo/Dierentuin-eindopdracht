namespace Dierentuin_eindopdracht.Models
{
    public class AnimalCategory
    {
        public int AnimalCategoryId { get; set; }
        public string Name { get; set; }

        //navigation properties
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}
