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
        public DbSet<SurveyResponse> SurveyResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .HasMany(s => s.SurveyResponses)
                .WithOne(sr => sr.Survey)
                .HasForeignKey(sr => sr.SurveyId);
                /*.Property(s => s.Responses)
                .HasConversion(new DictionaryToJsonConverter())
                .Metadata.SetValueComparer(DictionaryToJsonConverter.GetValueComparer());*/
        }
    }
}
