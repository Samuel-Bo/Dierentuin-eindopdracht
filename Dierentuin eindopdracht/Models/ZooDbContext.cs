using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Runtime.CompilerServices;

namespace Dierentuin_eindopdracht.Models
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }
        public DbSet<AnimalCategory> AnimalCategories { get; set; }
        public DbSet<Zoo> Zoos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Prevents cascade deletes
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Enclosure)
                .WithMany(e => e.Animals)
                .HasForeignKey(a => a.EnclosureId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Animals)
                .HasForeignKey(a => a.AnimalCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            // Seed data
            int animalAmount = 30;
            int enclosureAmount = 6;
            int categoryAmount = 7;
            int ZooAmount = 1;

            // Seed Enclosures
            var enclosures = GetEnclosures(enclosureAmount);
            modelBuilder.Entity<Enclosure>().HasData(enclosures);

            // Seed Animal Categories
            var categories = GetAnimalCategories(categoryAmount);
            modelBuilder.Entity<AnimalCategory>().HasData(categories);

            // Seed Zoos
            var zoos = GetZoos(ZooAmount);
            modelBuilder.Entity<Zoo>().HasData(zoos);

            // Seed Animals with references to seeded Enclosures and Categories
            var animals = GetAnimals(animalAmount, enclosures, categories);
            modelBuilder.Entity<Animal>().HasData(animals);
        }

        private static List<Animal> GetAnimals(int amount, List<Enclosure> enclosures, List<AnimalCategory> categories)
        {
            string[] speciesNames = { "Lion", "Tiger", "Elephant", "Giraffe", "Penguin", "Crocodile", "Zebra", "Wolf", "Eagle", "Shark" };
            string[] foods = { "Appel", "Banaan", "Broccoli", "Kip", "Zalm", "Pasta", "Rijst", "Tomaat", "Melk", "Ei" };

            var animalFaker = new Faker<Animal>()
                .UseSeed(1234)
                .RuleFor(x => x.AnimalId, f => f.IndexFaker + 1) // Sequential Animal Ids
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                .RuleFor(x => x.Species, f => f.PickRandom(speciesNames))
                .RuleFor(x => x.Prey, f => f.PickRandom(speciesNames))
                .RuleFor(x => x.SpaceRequirement, f => f.Random.Double(10, 500))
                .RuleFor(x => x.FeedingTime, f => f.PickRandom(foods))
                .RuleFor(x => x.Arise, f => f.Date.Timespan(TimeSpan.FromHours(6)))
                .RuleFor(x => x.BedTime, f => f.Date.Timespan(TimeSpan.FromHours(22)))
                .RuleFor(x => x.Size, f => f.PickRandom(Enum.GetValues<ZooEnums.Size>()))
                .RuleFor(x => x.DietaryClass, f => f.PickRandom(Enum.GetValues<ZooEnums.DietaryClass>()))
                .RuleFor(x => x.ActivityPattern, f => f.PickRandom(Enum.GetValues<ZooEnums.ActivityPattern>()))
                .RuleFor(x => x.SecurityRequirement, f => f.PickRandom(Enum.GetValues<ZooEnums.SecurityLevel>()))
                .RuleFor(x => x.ZooId, f => 1) // Assuming single zoo
                .RuleFor(x => x.EnclosureId, f => f.PickRandom(enclosures).EnclosureId) // Pick a random enclosure from the seed
                .RuleFor(x => x.AnimalCategoryId, f => f.PickRandom(categories).AnimalCategoryId) // Pick a random category from the seed
                .Generate(amount);

            return animalFaker;
        }

        private static List<Enclosure> GetEnclosures(int amount)
        {
            var enclosureFaker = new Faker<Enclosure>()
                .UseSeed(1234)
                .RuleFor(x => x.EnclosureId, f => f.IndexFaker + 1) // Sequential Enclosure Ids
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                .RuleFor(x => x.Size, f => f.Random.Double(10, 500))
                .RuleFor(x => x.Climate, f => f.PickRandom(Enum.GetValues<ZooEnums.Climate>()))
                .RuleFor(x => x.Habitat, f => f.PickRandom(Enum.GetValues<ZooEnums.HabitatType>()))
                .RuleFor(x => x.SecurityLevel, f => f.PickRandom(Enum.GetValues<ZooEnums.SecurityLevel>()))
                .RuleFor(x => x.ZooId, f => 1) // Assuming single zoo
                .Generate(amount);

            return enclosureFaker;
        }

        private static List<AnimalCategory> GetAnimalCategories(int amount)
        {
            string[] animalCategories = { "Mammals", "Reptiles", "Birds", "Amphibians", "Fish", "Insects", "Arachnids" };

            var animalCategoryFaker = new Faker<AnimalCategory>()
                .UseSeed(1234)
                .RuleFor(x => x.AnimalCategoryId, f => f.IndexFaker + 1) // Sequential Category Ids
                .RuleFor(x => x.Name, f => f.PickRandom(animalCategories))
                .Generate(amount);

            return animalCategoryFaker;
        }

        private static List<Zoo> GetZoos(int amount)
        {
            var zooFaker = new Faker<Zoo>()
                .UseSeed(1234)
                .RuleFor(x => x.ZooId, f => f.IndexFaker + 1) // Sequential Zoo Ids
                .RuleFor(x => x.Name, f => f.Company.CompanyName())
                .Generate(amount);

            return zooFaker;
        }


    }
}
