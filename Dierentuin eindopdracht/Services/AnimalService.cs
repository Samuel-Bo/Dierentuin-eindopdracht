using Dierentuin_eindopdracht.Models;
using Microsoft.AspNetCore.Mvc;
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

        public List<Animal> EmptyEnclosureGet() //returns the animals where the enclosre is null
        {
            var animals = context.Animals
                .Where(a => a.EnclosureId == null)
                .ToList();

            return animals;
        }

        public List<Animal> EmptyCategoryGet()
        {
            var animals = context.Animals
                .Where(a => a.AnimalCategoryId == null)
                .ToList();

            return animals;
        }

        public void CreateAnimal(AnimalDto animalDto) //creating and adding a new enclosure to the database
        {
            var animal = new Animal
            {
                Name = animalDto.Name,
                Species = animalDto.Species,
                Prey = animalDto.Prey,
                SpaceRequirement = animalDto.SpaceRequirement,
                FeedingTime = animalDto.FeedingTime,
                Arise = animalDto.Arise,
                BedTime = animalDto.BedTime,
                Size = animalDto.Size,
                DietaryClass = animalDto.DietaryClass,
                ActivityPattern = animalDto.ActivityPattern,
                SecurityRequirement = animalDto.SecurityRequirement,
                EnclosureId = animalDto.EnclosureId,
                AnimalCategoryId = animalDto.AnimalCategoryId,
                ZooId = 1
            };

            context.Animals.Add(animal);
            context.SaveChanges();

            Console.WriteLine("Animal successfully saved to database!");
        }
    }
}
