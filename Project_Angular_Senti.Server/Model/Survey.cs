using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Angular_Senti.Server.Model
{
    [Table("SurveyDBs")]
    public class Survey
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Respondent { get; set; }
        [Required]
        public Dictionary<string, string> Responses { get; set; } = new Dictionary<string, string>();



    }
}
