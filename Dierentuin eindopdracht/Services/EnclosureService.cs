using Dierentuin_eindopdracht.Models;

namespace Dierentuin_eindopdracht.Services
{
    public class EnclosureService
    {
        private readonly ZooDbContext context;
        public EnclosureService(ZooDbContext context)
        {
            this.context = context;
        }
        public List<Enclosure> GetEnclosures()
        {
            var enclosures = context.Enclosures.OrderByDescending(e => e.EnclosureId).ToList();
            return enclosures;
        }
    }
}
