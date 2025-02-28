using Microsoft.EntityFrameworkCore;
using Project_Angular_Senti.Server.Model;

namespace Project_Angular_Senti.Server.Data
{

    public class SurveyContext : DbContext
    {
        public SurveyContext(
            DbContextOptions<SurveyContext> options) : base(options)
        {
        }

        public DbSet<Survey> Survey { get; set; }
    }
}
