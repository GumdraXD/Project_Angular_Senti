namespace Project_Angular_Senti.Server.Model
{
    public class SurveyRequest
    {
        public string Respondent { get; set; }
        public List<SurveyResponseRequest> SurveyResponses { get; set; }
    }

    public class SurveyResponseRequest
    {
        public string Question { get; set; }
        public string Response { get; set; }
    }
}
