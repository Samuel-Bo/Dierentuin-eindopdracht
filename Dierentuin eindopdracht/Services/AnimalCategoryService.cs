using Dierentuin_eindopdracht.Models;

namespace Dierentuin_eindopdracht.Services
{
    public class AnimalCategoryService
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
    }
}
