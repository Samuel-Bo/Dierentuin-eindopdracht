using Microsoft.EntityFrameworkCore;

namespace Dierentuin_eindopdracht.Models
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options) : base(options)
        {
        }
    }
}
