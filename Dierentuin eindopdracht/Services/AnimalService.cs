using Dierentuin_eindopdracht.Models;
using Microsoft.EntityFrameworkCore;

namespace Dierentuin_eindopdracht.Services
{
    public class AnimalService //Class for animal logic
    {
        private readonly ZooDbContext context;
        public AnimalService(ZooDbContext context)
        {
            this.context = context;
        }
        public List<Animal> GetAnimals() //list for animal index
        {
            var animals = context.Animals
            .Include(a => a.Enclosure)  // Include Enclosures
            .Include(a => a.Category)   // Include Categories
            .OrderByDescending(a => a.AnimalId)  //Descending to see new animals at the top
            .ToList();

            return animals;
        }
    }
}
