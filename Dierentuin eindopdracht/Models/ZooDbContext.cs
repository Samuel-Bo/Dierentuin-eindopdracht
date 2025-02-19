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

        //dbsets
        public DbSet<Animal> animals;
        public DbSet<Enclosure> enclosures;
        public DbSet<Category> categories;
        public DbSet<Zoo> zoos;

        //seeding temps
        public static List<Zoo> _zoos;
        public static List<Enclosure> _enclosures;
        public static List<Animal> _animals;
        public static List<Category> _categories;

        //flag
        private bool s_seeded = false;

        //seeding

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
                .OnDelete(DeleteBehavior.SetNull); // Sets CategoryId to null when Category is deleted

            Seed();
            modelBuilder.Entity<Animal>().HasData(_animals);
            modelBuilder.Entity<Enclosure>().HasData(_enclosures);
            modelBuilder.Entity<Category>().HasData(_categories);
            modelBuilder.Entity<Zoo>().HasData(_zoos);
        }

        protected void Seed()
        {
            if (s_seeded) { return; }
            s_seeded = true;

            const int zooAmount = 10;
            const int enclosureAmount = zooAmount * 2;
            const int animalAmount = enclosureAmount * 2;
            const int categoryAmount = 10;

            //hard to find proper seeding names so made array's
            String[] categorieNames = new[] { "Mammals", "Reptiles", "Birds", "Fishes", "Insects" };
            String[] speciesNames = new[] { "Lion", "Tiger", "Elephant", "Giraffe", "Penguin", "Kangaroo", "Cobra", "Eagle" };

            //Zoo fake data
            _zoos = new Faker<Zoo>()
                .RuleFor(o => o.ZooId, f => f.IndexFaker + 1)
                .RuleFor(o => o.Name, f => f.Name.FullName())
                .Generate(zooAmount);

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
                .RuleFor(o => o.Name, f => f.PickRandom(categorieNames))
                .Generate(categoryAmount);

            // Animal fake data
            _animals = new Faker<Animal>()
                .RuleFor(o => o.AnimalId, f => f.IndexFaker + 1)
                .RuleFor(o => o.Name, f => f.Name.FirstName())
                .RuleFor(o => o.Species, f => f.PickRandom(speciesNames))
                .RuleFor(o => o.Prey, f => f.Lorem.Word())
                .RuleFor(o => o.SpaceRequirement, f => f.Random.Double(10, 500))
                .RuleFor(o => o.FeedingTime, f => f.Date.Timespan(TimeSpan.FromHours(2)))
                .RuleFor(o => o.Arise, f => f.Date.Timespan(TimeSpan.FromHours(6)))
                .RuleFor(o => o.BedTime, f => f.Date.Timespan(TimeSpan.FromHours(22)))
                .RuleFor(o => o.Size, f => f.PickRandom<ZooEnums.Size>())
                .RuleFor(o => o.DietaryClass, f => f.PickRandom<ZooEnums.DietaryClass>())
                .RuleFor(o => o.ActivityPattern, f => f.PickRandom<ZooEnums.ActivityPattern>())
                .RuleFor(o => o.SecurityRequirment, f => f.PickRandom<ZooEnums.SecurityLevel>())
                .Generate(animalAmount);
            
            //seeding relationships between models
            foreach (var zoo in _zoos)
            {
                // Enclosure >---| Zoo
                _enclosures.OrderBy(x => Random.Shared.Next())
                    .Where(e => e.ZooId == 0)
                    .Take(enclosureAmount / zooAmount)  // Equally tries to distribute enclosures among zoos
                    .ToList().ForEach(e => e.ZooId = zoo.ZooId);

                //  Animals >---| Enclosure (within the Same Zoo)
                _animals.OrderBy(x => Random.Shared.Next())
                    .Where(a => a.ZooId == 0)  
                    .Take(animalAmount / zooAmount)  // Equally tries to distribute animals among zoos
                    .ToList().ForEach(a =>
                    {
                        // Current Zoo that's being interated through get's a new animal
                        a.ZooId = zoo.ZooId;

                        // Makes it so animal gets enclosure within the same zoo
                        a.EnclosureId = _enclosures.Where(e => e.ZooId == zoo.ZooId).OrderBy(x => Random.Shared.Next()).FirstOrDefault().EnclosureId;

                        // Random category for the animal
                        a.CategoryId = _categories.OrderBy(c => Random.Shared.Next()).FirstOrDefault().CategoryId;
                    });
            }
        }
    }
}
