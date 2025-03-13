using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Angular_Senti.Server.Model
{
    [Table("SurveyResponses")]
    public class SurveyResponse
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Survey")]
        public int SurveyId { get; set; }

        public Survey Survey { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Response { get; set; }
    }
}
