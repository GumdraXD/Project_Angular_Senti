using Microsoft.EntityFrameworkCore;

namespace Project_Angular_Senti.Server
{
    public class SurveyContext : DbContext 
    {
        public SurveyContext (
            DbContextOptions<SurveyContext> options): base(options) 
        { 
        }

        public DbSet<Survey> Survey { get; set; }
    }
}
