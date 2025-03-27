using Dierentuin_eindopdracht.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Dierentuin_eindopdracht.Services
{
    public class EnclosureService //class for enclosure logic
    {
        private readonly ZooDbContext context;
        public EnclosureService(ZooDbContext context)
        {
            this.context = context;
        }
        public Enclosure FindEnclosure(int id)
        {
            
            var enclosure = context.Enclosures.Find(id);

            return enclosure;
            
        }
        public List<Enclosure> GetEnclosures()
        {
            var enclosures = context.Enclosures
                .Include(e => e.Animals)
                .OrderByDescending(e => e.EnclosureId)
                .ToList();

            

            return enclosures;
        }
        public void CreateEnclosure(EnclosureDto enclosureDto) //creating and adding a new enclosure to the database
        {
            var enclosure = new Enclosure
            {
                Name = enclosureDto.Name,
                Size = enclosureDto.Size,
                Climate = enclosureDto.Climate,
                Habitat = enclosureDto.Habitat,
                SecurityLevel = enclosureDto.SecurityLevel,
                ZooId = 1,
            };

            if (enclosureDto.SelectedAnimalIds != null && enclosureDto.SelectedAnimalIds.Any()) //if any id's are sent to the list in the dto the query will search 
            {                                                                                   //the animals that belong to the Id's.
                enclosure.Animals = context.Animals
                .Where(a => enclosureDto.SelectedAnimalIds.Contains(a.AnimalId))
                .ToList();
            }
         

            context.Enclosures.Add(enclosure);
            context.SaveChanges();

            Console.WriteLine("Enclosure successfully saved to database!");
        }
        public Enclosure GetEnclosureAnimals(int id) //shows all animals that are linked to the current enclosure
        {
            return context.Enclosures
                    .Include(e => e.Animals)  // Gets the animals of the enclosure where the enclosureId equals the parameter id
                    .FirstOrDefault(e => e.EnclosureId == id); 
        }

        public EnclosureDto ShowEnclosure(int id) //shows the enclosure that you're trying to edit
        {
            var enclosure = FindEnclosure(id);

            var enclosureDto = new EnclosureDto
            {
                Name = enclosure.Name,
                Size = enclosure.Size,
                Climate = enclosure.Climate,
                Habitat = enclosure.Habitat,
                SecurityLevel = enclosure.SecurityLevel,
                Animals = enclosure.Animals
            };

            return enclosureDto;
        }

        public void RemoveAllEnclosures()
        {
            var enclosures = context.Enclosures
                .ToList();

            var animals = context.Animals
                .ToList();

            foreach (var animal in animals) 
            { 
                animal.EnclosureId = null;
            }

            foreach (var enclosure in enclosures)
            {
                

                context.Enclosures.Remove(enclosure);
            }

            context.SaveChanges();

        }

        public Enclosure RandomEnclosure()
        {
            
            
            var random = new Random();
            var climate = Enum.GetValues(typeof(ZooEnums.Climate));
            var habitat = Enum.GetValues(typeof(ZooEnums.HabitatType));
            var securityLevel = Enum.GetValues(typeof (ZooEnums.SecurityLevel));


            int randomEnclosures = random.Next(6);



            for (int i = 0; i < randomEnclosures; i++)
            {
                
                var enclosure =  new Enclosure
                {
                    Name = "Auto Enclosure",
                    Size = random.NextDouble(),
                    Climate = (ZooEnums.Climate)climate.GetValue(random.Next(climate.Length)),
                    Habitat = (ZooEnums.HabitatType)habitat.GetValue(random.Next(habitat.Length)),
                    SecurityLevel = (ZooEnums.SecurityLevel)securityLevel.GetValue(random.Next(securityLevel.Length)),
                    ZooId = 1

                };

            }

            context.SaveChanges();

            context.SaveChanges();

            return enclosure;
        }

        public void EditEnclosure(int id, EnclosureDto enclosureDto)
        {
            var enclosure = FindEnclosure(id);

            enclosure.Name = enclosureDto.Name;
            enclosure.Size = enclosureDto.Size;
            enclosure.Climate = enclosureDto.Climate;
            enclosure.Habitat = enclosureDto.Habitat;
            enclosure.SecurityLevel = enclosureDto.SecurityLevel;
            enclosure.ZooId = 1;

            if (enclosure.Animals == null) //we need this to avoid a nullexception error when we try Animals.Add later on
            {
                enclosure.Animals = new List<Animal>();
            }

            if (enclosureDto.SelectedAnimalIds != null && enclosureDto.SelectedAnimalIds.Any()) // adds all of the animals that were selected at Add
            {
                ICollection<Animal> addAnimals = context.Animals
                    .Where(a => enclosureDto.SelectedAnimalIds.Contains(a.AnimalId))
                    .ToList();

                foreach (Animal animal in addAnimals)
                {
                    if (!enclosure.Animals.Contains(animal) && enclosure.Size >= animal.SpaceRequirement) // Prevent duplicates and checks if the animal fits
                    {
                        enclosure.Animals.Add(animal);
                    }
                    else
                    {
                        Console.WriteLine("This animal doesnt fit");
                    }
                    
                }
            }



            // Remove deleted animals
            if (enclosureDto.DeleteAnimalIds != null && enclosureDto.DeleteAnimalIds.Any()) // removes all of the animals that were selected at Delete
            {
                ICollection<Animal> deleteAnimals = context.Animals
                    .Where(a => enclosureDto.DeleteAnimalIds.Contains(a.AnimalId))
                    .ToList();

                foreach (Animal animal in deleteAnimals)
                {
                    animal.EnclosureId = null;
                    enclosure.Animals.Remove(animal);  // Remove from list
                }
            }

            Console.WriteLine("DEBUG: Saving changes to database...");
            context.SaveChanges();
            Console.WriteLine("DEBUG: Changes saved successfully!");
        }
        public void DeleteEnclosure(int id) //deleting enclosures
        {
            var enclosure = context.Enclosures.Find(id);

            if (enclosure == null)
            {
                Console.WriteLine("enclosure not found");
            }

            // Sets EnclosureId to NULL to break foreign key dependency, This app doesn't use cascade delete
            var animalsInEnclosure = context.Animals.Where(a => a.EnclosureId == id).ToList(); 
            foreach (var animal in animalsInEnclosure)
            {
                animal.EnclosureId = null; 
            }

            context.Enclosures.Remove(enclosure);
            Console.WriteLine("enclosure removed");
            context.SaveChanges();
            Console.WriteLine("changes saved");
        }

        public List<Animal> GetSunsetAnimals(int id)
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            var animals = context.Animals
                .Where(a => a.EnclosureId == id)
                .ToList();

            var sleepyAnimals = animals
                .Where(a => (a.BedTime < a.Arise && currentTime >= a.BedTime && currentTime < a.Arise) // for when animals sleep throught the day
                 || (a.BedTime > a.Arise && (currentTime >= a.BedTime || currentTime < a.Arise))) // for when animals sleep in the night
                .ToList();

            return sleepyAnimals;
        }

        public List<Animal> GetSunriseAnimals(int id)
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            var animals = context.Animals
                .Where(a => a.EnclosureId == id)
                .ToList();

            var wakeyAnimals = animals
                .Where(a => (a.BedTime > a.Arise && currentTime <= a.BedTime && currentTime > a.Arise) // for when animals sleep throught the day
                         || (a.BedTime < a.Arise && (currentTime <= a.BedTime || currentTime > a.Arise))) // for when animals sleep in the night
                .ToList();

            return wakeyAnimals;
        }
    }
}
