using Dierentuin_eindopdracht.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dierentuin_eindopdracht.Services
{
    public class EnclosureService //class for enclosure logic
    {
        private readonly ZooDbContext context;
        public EnclosureService(ZooDbContext context)
        {
            this.context = context;
        }
        public List<Enclosure> GetEnclosures()
        {
            var enclosures = context.Enclosures
                .Include(e => e.Animals)
                .OrderByDescending(e => e.EnclosureId).ToList();

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
                Animals = enclosureDto.Animals,
                ZooId = 1
            };

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
    }
}
