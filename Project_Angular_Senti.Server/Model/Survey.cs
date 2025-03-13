using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Project_Angular_Senti.Server.Model
{
    [Table("Surveys")]
    public class Survey
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Respondent { get; set; }

        public List<SurveyResponse> SurveyResponses { get; set; } = new List<SurveyResponse>();
        
        /*
        [Required]
        public string ResponsesJson { get; set; }
        public Dictionary<string, object> Responses 
        {
            get => string.IsNullOrEmpty(ResponsesJson) ?
                new Dictionary<string, object>() : JsonSerializer.Deserialize<Dictionary<string, object>>(ResponsesJson);
            set => ResponsesJson = JsonSerializer.Serialize(
                value, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } });
        }*/



    }
}
