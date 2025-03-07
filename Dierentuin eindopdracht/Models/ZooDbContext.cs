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
            //enter seeding values here
            int animalAmount = 30;
            int enclosureAmount = 6;
            int categoryAmount = 7;
            int ZooAmount = 1;

            //prevents cascade deletes, animals still exist when a category or enclosure is deleted.
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

            modelBuilder.Entity<Animal>().HasData(GetAnimals(animalAmount, enclosureAmount, categoryAmount));
            modelBuilder.Entity<Enclosure>().HasData(GetEnclosures(enclosureAmount));
            modelBuilder.Entity<AnimalCategory>().HasData(GetAnimalCategories(categoryAmount));
            modelBuilder.Entity<Zoo>().HasData(GetZoos(ZooAmount));

        }

        private static List<Animal> GetAnimals(int amount, int enclosures, int categories)
        {
            string[] speciesNames = { "Lion", "Tiger", "Elephant", "Giraffe", "Penguin", "Crocodile", "Zebra", "Wolf", "Eagle", "Shark" };
            string[] foods = { "Appel", "Banaan", "Broccoli", "Kip", "Zalm", "Pasta", "Rijst", "Tomaat", "Melk", "Ei" };

            var Id = 1;

            var animalFaker = new Faker<Animal>()
                .UseSeed(1234)
                .RuleFor(x => x.AnimalId, f => Id++)
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
                .RuleFor(x => x.ZooId, f => 1)
                .RuleFor(x => x.EnclosureId, f => f.Random.Int(1, enclosures)) //based on the amount of enclosures gives a random value between 1 and amount
                .RuleFor(x => x.AnimalCategoryId, f => f.Random.Int(1, categories)) //based on the amount of categories gives a random value between 1 and amount
                .Generate(amount);

            return animalFaker;
        }

        private static List<Enclosure> GetEnclosures(int amount)
        {
            var Id = 1;
            var enclosureFaker = new Faker<Enclosure>()
                .UseSeed(1234)
                .RuleFor(x => x.EnclosureId, f => Id++)
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                .RuleFor(x => x.Size, f => f.Random.Double(10, 500))
                .RuleFor(x => x.Climate, f => f.PickRandom(Enum.GetValues<ZooEnums.Climate>()))
                .RuleFor(x => x.Habitat, f => f.PickRandom(Enum.GetValues<ZooEnums.HabitatType>()))
                .RuleFor(x => x.SecurityLevel, f => f.PickRandom(Enum.GetValues<ZooEnums.SecurityLevel>()))
                .RuleFor(x => x.Animals, f => new List<Animal>())
                .RuleFor(x => x.ZooId, f => 1)
                .Generate(amount);

            return enclosureFaker;
        }

        private static List<AnimalCategory> GetAnimalCategories(int amount)
        {
            string[] animalCategories = { "Mammals", "Reptiles", "Birds", "Amphibians", "Fish", "Insects", "Arachnids" };

            var Id = 1;
            var animalCategoryFaker = new Faker<AnimalCategory>()
                .UseSeed(1234)
                .RuleFor(x => x.AnimalCategoryId, f => Id++)
                .RuleFor(x => x.Name, f => f.PickRandom(animalCategories))
                .Generate(amount);

            return animalCategoryFaker;
        }

        private static List<Zoo> GetZoos(int amount)
        {
            var Id = 1;
            var zooFaker = new Faker<Zoo>()
                .UseSeed(1234)
                .RuleFor(x => x.ZooId, f => Id++)
                .RuleFor(x => x.Name, f => f.Company.CompanyName())
                .RuleFor(x => x.Animals, f => new List<Animal>())
                .RuleFor(x => x.Enclosures, f => new List<Enclosure>())
                .Generate(amount);

            return zooFaker;
        }
    }
}
