using Bogus.DataSets;
using Dierentuin_eindopdracht.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static Dierentuin_eindopdracht.Models.ZooEnums;

namespace Dierentuin_eindopdracht.Services
{
    public class AnimalService //Class for animal logic
    {
        private readonly ZooDbContext context;
        public AnimalService(ZooDbContext context)
        {
            this.context = context;
        }
        public Animal FindAnimal(int id)
        {

            var animal = context.Animals.Find(id);

            return animal;

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
        public List<Animal> EnclosureGet(int id) //returns the animals of an enclosure
        {
            var animals = context.Animals.
                Where(a => a.EnclosureId == id)
                .ToList();

            return animals;
        }

        public List<Animal> CategoryGet(int id) //returns the animals of an enclosure
        {
            var animals = context.Animals.
                Where(a => a.AnimalCategoryId == id)
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

        public void AutoAssignAnimals()
        {

            var animals = context.Animals
                .Where(a => a.EnclosureId == null)
                .ToList();

            var enclosures = context.Enclosures
                .Select(e=>e.EnclosureId)
                .ToList();

            var random = new Random();

            foreach (var animal in animals)
            {

                int randomIndex = random.Next(0, enclosures.Count);

                animal.EnclosureId = enclosures[randomIndex];
                
                context.Entry(animal).Property(a=>a.EnclosureId).IsModified = true;
            }

            context.SaveChanges();

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
        public AnimalDto ShowAnimal(int id) //shows the animal that you're trying to edit
        {
            var animal = FindAnimal(id);

            var animalDto = new AnimalDto
            {
                Name = animal.Name,
                Species = animal.Species,
                Prey = animal.Prey,
                SpaceRequirement = animal.SpaceRequirement,
                FeedingTime = animal.FeedingTime,
                Arise = animal.Arise,
                BedTime = animal.BedTime,
                Size = animal.Size,
                DietaryClass = animal.DietaryClass,
                ActivityPattern = animal.ActivityPattern,
                SecurityRequirement = animal.SecurityRequirement,
                EnclosureId = animal.EnclosureId,
                AnimalCategoryId = animal.AnimalCategoryId,
            };

            return animalDto;
        }
        public void EditAnimal(int id, AnimalDto animalDto) //Actually edits animals
        {
            var animal = FindAnimal(id);

            animal.Name = animalDto.Name;
            animal.Species = animalDto.Species;
            animal.Prey = animalDto.Prey;
            animal.SpaceRequirement = animalDto.SpaceRequirement;
            animal.FeedingTime = animalDto.FeedingTime;
            animal.Arise = animalDto.Arise;
            animal.BedTime = animalDto.BedTime;
            animal.Size = animalDto.Size;
            animal.DietaryClass = animalDto.DietaryClass;
            animal.ActivityPattern = animalDto.ActivityPattern;
            animal.SecurityRequirement = animalDto.SecurityRequirement;
            animal.EnclosureId = animalDto.EnclosureId;
            animal.AnimalCategoryId = animalDto.AnimalCategoryId;
            animal.ZooId = 1;

            Console.WriteLine("DEBUG: Saving changes to database...");
            context.SaveChanges();
            Console.WriteLine("DEBUG: Changes saved successfully!");
        }
        public void DeleteAnimal(int id) //deleting animals
        {
            var animal = context.Animals.Find(id);

            if (animal == null)
            {
                Console.WriteLine("animal not found");
            }

            context.Animals.Remove(animal);
            Console.WriteLine("animal removed");
            context.SaveChanges();
            Console.WriteLine("changes saved");
        }

        public List<Animal> GetSunsetAnimals()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            var sleepyAnimals = context.Animals
                .Where(a => (a.BedTime < a.Arise && currentTime >= a.BedTime && currentTime < a.Arise) // for when animals sleep throught the day
                         || (a.BedTime > a.Arise && (currentTime >= a.BedTime || currentTime < a.Arise))) // for when animals sleep in the night
                .ToList();

            return sleepyAnimals;
        }
        public List<Animal> GetSunriseAnimals()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            var wakeyAnimals = context.Animals
                .Where(a => (a.BedTime > a.Arise && currentTime <= a.BedTime && currentTime > a.Arise) // for when animals sleep throught the day
                         || (a.BedTime < a.Arise && (currentTime <= a.BedTime || currentTime > a.Arise))) // for when animals sleep in the night
                .ToList();

            return wakeyAnimals;
        }

        public List<Animal> FilterAnimals(string filter)
        {
            var animals = context.Animals.Include(a => a.Enclosure).Include(a => a.Category);

            switch (filter.ToLower())
            {
                case "id":
                    return animals.OrderBy(a => a.AnimalId).ToList();
                case "name":
                    return animals.OrderBy(a => a.Name).ToList();
                case "species":
                    return animals.OrderBy(a => a.Species).ToList();
                case "prey":
                    return animals.OrderBy(a => a.Prey).ToList();
                case "spacerequirement":
                    return animals.OrderBy(a => a.SpaceRequirement).ToList();
                case "feedingtime":
                    return animals.OrderBy(a => a.FeedingTime).ToList();
                case "arise":
                    return animals.OrderBy(a => a.Arise).ToList();
                case "bedtime":
                    return animals.OrderBy(a => a.BedTime).ToList();
                case "size":
                    return animals.OrderBy(a => a.Size).ToList();
                case "dietaryclass":
                    return animals.OrderBy(a => a.DietaryClass).ToList();
                case "activitypattern":
                    return animals.OrderBy(a => a.ActivityPattern).ToList();
                case "securityrequirement":
                    return animals.OrderBy(a => a.SecurityRequirement).ToList();
                case "enclosure":
                    return animals.OrderBy(a => a.Enclosure != null ? a.Enclosure.Name : "").ToList();
                case "category":
                    return animals.OrderBy(a => a.Category != null ? a.Category.Name : "").ToList();
                default:
                    return animals.OrderBy(a => a.AnimalId).ToList();
            }
        }
    }
}
