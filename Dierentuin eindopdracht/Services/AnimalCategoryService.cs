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

            if (categoryDto.SelectedAnimalIds != null && categoryDto.SelectedAnimalIds.Any()) //if any id's are sent to the list in the dto the query will search the 
            {                                                                                   //the animals where they belong to.
                category.Animals = context.Animals
                .Where(a => categoryDto.SelectedAnimalIds.Contains(a.AnimalId))
                .ToList();
            }

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
