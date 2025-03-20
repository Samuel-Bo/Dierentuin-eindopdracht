using Dierentuin_eindopdracht.Models;
using Microsoft.EntityFrameworkCore;

namespace Dierentuin_eindopdracht.Services
{
    public class AnimalCategoryService// class for category logic
    {
        private readonly ZooDbContext context;
        public AnimalCategoryService(ZooDbContext context)
        {
            this.context = context;
        }

        public List<AnimalCategory> GetCategories() //list for category index
        {
            var categories = context.AnimalCategories.OrderByDescending(e => e.AnimalCategoryId).ToList();
            return categories;
        }

        public void CreateCategory(AnimalCategoryDto categoryDto) //creating and adding a new category to the database
        {
            var category = new AnimalCategory
            {
                Name = categoryDto.Name,
            };

            context.AnimalCategories.Add(category);
            context.SaveChanges();

            Console.WriteLine("AnimalCategory successfully saved to database!");
        }

        public AnimalCategory GetCategoryAnimals(int id) // get the Animalcategorie by Id and include it's animals
        {
            return context.AnimalCategories
                .Include(c => c.Animals)
                .FirstOrDefault(c => c.AnimalCategoryId == id);
        }
    }
}
