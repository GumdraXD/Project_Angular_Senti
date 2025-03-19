namespace Project_Angular_Senti.Server.Model
{
    public class CsvUploadModel
    {
        public IFormFile File { get; set; } = null!;
        public string IdentifierColum { get; set; } = "DatasetName";
    }
}
