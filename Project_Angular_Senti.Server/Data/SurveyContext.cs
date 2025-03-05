using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .Property(s => s.Responses)
                .HasConversion(new DictionaryToJsonConverter())
                .Metadata.SetValueComparer(DictionaryToJsonConverter.GetValueComparer());
        }
    }
}
