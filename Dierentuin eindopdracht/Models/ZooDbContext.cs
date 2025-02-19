using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Zoo> Zoos { get; set; }

        // Temporary seeding lists
        public static List<Zoo> _zoos;
        public static List<Enclosure> _enclosures;
        public static List<Animal> _animals;
        public static List<Category> _categories;

        // Flag to check if seeding has already been done
        private bool s_seeded = false;

        // Seeding data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // EnclosureId becomes null for animals after delete
            modelBuilder.Entity<Enclosure>()
                .HasMany(e => e.Animals)
                .WithOne(a => a.Enclosure)
                .HasForeignKey(a => a.EnclosureId)
                .OnDelete(DeleteBehavior.SetNull); // Set EnclosureId to null when Enclosure is deleted

            // CategoryId becomes null for animals after delete
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Animals)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.SetNull); // Set CategoryId to null when Category is deleted

            Seed(); // Seeding data
            modelBuilder.Entity<Animal>().HasData(_animals);
            modelBuilder.Entity<Enclosure>().HasData(_enclosures);
            modelBuilder.Entity<Category>().HasData(_categories);
            modelBuilder.Entity<Zoo>().HasData(_zoos);
        }

        protected void Seed()
        {
            if (s_seeded) { return; }
            s_seeded = true;

            const int enclosureAmount = 6;  // Number of enclosures
            const int animalAmount = enclosureAmount * 5;  // Number of animals
            const int categoryAmount = 5;  // Number of categories

            // Category names
            String[] categoryNames = new[] { "Mammals", "Reptiles", "Birds", "Fishes", "Insects" };
            String[] speciesNames = new[] { "Lion", "Tiger", "Elephant", "Giraffe", "Penguin"};

            // One single zoo
            _zoos = new Faker<Zoo>()
                .RuleFor(o => o.ZooId, f => 1)  // Single Zoo
                .RuleFor(o => o.Name, f => f.Company.CompanyName())
                .Generate(1);  // Only 1 zoo because the web app manages ONE zoo only

            // Enclosure fake data
            _enclosures = new Faker<Enclosure>()
                .RuleFor(o => o.EnclosureId, f => f.IndexFaker + 1)
                .RuleFor(o => o.Name, f => f.Lorem.Word())
                .RuleFor(o => o.Size, f => f.Random.Double(100, 999))
                .RuleFor(o => o.Climate, f => f.PickRandom<ZooEnums.Climate>())
                .RuleFor(o => o.Habitat, f => f.PickRandom<ZooEnums.HabitatType>())
                .RuleFor(o => o.SecurityLevel, f => f.PickRandom<ZooEnums.SecurityLevel>())
                .Generate(enclosureAmount);

            // Category fake data
            _categories = new Faker<Category>()
                .RuleFor(o => o.CategoryId, f => f.IndexFaker + 1)
                .RuleFor(o => o.Name, f => f.PickRandom(categoryNames))
                .Generate(categoryAmount);

            // Animal fake data
            _animals = new Faker<Animal>()
                .RuleFor(o => o.AnimalId, f => f.IndexFaker + 1)
                .RuleFor(o => o.Name, f => f.Name.FirstName())
                .RuleFor(o => o.Species, f => f.PickRandom(speciesNames))
                .RuleFor(o => o.Prey, f => f.PickRandom(speciesNames))
                .RuleFor(o => o.SpaceRequirement, f => f.Random.Double(10, 500))
                .RuleFor(o => o.FeedingTime, f => f.Date.Timespan(TimeSpan.FromHours(2)))
                .RuleFor(o => o.Arise, f => f.Date.Timespan(TimeSpan.FromHours(6)))
                .RuleFor(o => o.BedTime, f => f.Date.Timespan(TimeSpan.FromHours(22)))
                .RuleFor(o => o.Size, f => f.PickRandom<ZooEnums.Size>())
                .RuleFor(o => o.DietaryClass, f => f.PickRandom<ZooEnums.DietaryClass>())
                .RuleFor(o => o.ActivityPattern, f => f.PickRandom<ZooEnums.ActivityPattern>())
                .RuleFor(o => o.SecurityRequirment, f => f.PickRandom<ZooEnums.SecurityLevel>())
                .Generate(animalAmount);

            // Assigning Enclosures, Categories, and Zoo to Animals
            foreach (var animal in _animals)
            {
                // Assign a random enclosure from the zoo
                animal.EnclosureId = _enclosures.OrderBy(e => Random.Shared.Next()).FirstOrDefault().EnclosureId;

                // Assign a random category
                animal.CategoryId = _categories.OrderBy(c => Random.Shared.Next()).FirstOrDefault().CategoryId;

                // Assign the single zoo to all animals
                animal.ZooId = _zoos.FirstOrDefault()?.ZooId ?? 1;
            }

            foreach(var enclosure in _enclosures)
            {
                //Assing every enclosure to the Zoo
                enclosure.ZooId = _zoos.FirstOrDefault()?.ZooId ?? 1;
            }
        }
    }
}
