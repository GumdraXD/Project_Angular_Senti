/* Practice for Connecting Db

using Microsoft.EntityFrameworkCore;
using Project_Angular_Senti.Server.Model;

namespace Project_Angular_Senti.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
*/