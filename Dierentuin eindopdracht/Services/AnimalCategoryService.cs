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
        public AnimalCategory FindCategory(int id)
        {

            var category = context.AnimalCategories.Find(id);

            return category;

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

        public AnimalCategory GetCategoryAnimals(int id) // get the Animalcategory by Id and include it's animals
        {
            return context.AnimalCategories
                .Include(c => c.Animals)
                .FirstOrDefault(c => c.AnimalCategoryId == id);
        }

        public AnimalCategoryDto ShowCategory(int id) //shows the category that you're trying to edit
        {
            var category = FindCategory(id);

            var categoryDto = new AnimalCategoryDto
            {
                Name = category.Name,
                Animals = category.Animals
            };

            return categoryDto;
        }
        public void EditCategory(int id, AnimalCategoryDto categoryDto) //actually edits the category
        {
            var category = FindCategory(id);

            category.Name = categoryDto.Name;

            if (category.Animals == null) //we need this to avoid a nullexception error when we try Animals.Add later on
            {
                category.Animals = new List<Animal>();
            }

            
            if (categoryDto.SelectedAnimalIds != null && categoryDto.SelectedAnimalIds.Any())// adds all of the animals that were selected at Add
            {
                ICollection<Animal> addAnimals = context.Animals
                    .Where(a => categoryDto.SelectedAnimalIds.Contains(a.AnimalId))
                    .ToList();

                foreach (Animal animal in addAnimals)
                {
                    if (!category.Animals.Contains(animal)) // Prevent duplicates
                    {
                        category.Animals.Add(animal);
                    }
                }
            }

            // Remove deleted animals
            if (categoryDto.DeleteAnimalIds != null && categoryDto.DeleteAnimalIds.Any())
            {
                ICollection<Animal> deleteAnimals = context.Animals
                    .Where(a => categoryDto.DeleteAnimalIds.Contains(a.AnimalId))
                    .ToList();

                foreach (Animal animal in deleteAnimals)
                {
                    animal.EnclosureId = null;
                    category.Animals.Remove(animal);  // Remove from list
                }
            }

            Console.WriteLine("DEBUG: Saving changes to database...");
            context.SaveChanges();
            Console.WriteLine("DEBUG: Changes saved successfully!");
        }
        public void DeleteCategory(int id) //deleting categories
        {
            var category = context.AnimalCategories.Find(id);

            if (category == null)
            {
                Console.WriteLine("category not found");
            }

            // Sets AnimalCategoryId to NULL to break foreign key dependency, This app doesn't use cascade delete
            var animalsInCategory = context.Animals.Where(a => a.AnimalCategoryId == id).ToList();
            foreach (var animal in animalsInCategory)
            {
                animal.AnimalCategoryId = null;
            }

            context.AnimalCategories.Remove(category);
            Console.WriteLine("category removed");
            context.SaveChanges();
            Console.WriteLine("changes saved");
        }
    }
}
