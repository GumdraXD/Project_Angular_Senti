using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Angular_Senti.Server.Model;
using Project_Angular_Senti.Server.Data;
using System.Threading.Tasks;


namespace Project_Angular_Senti.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        private readonly IcsvService _csvService;

        public CsvController(IcsvService csvService)
        {
            _csvService = csvService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadCsv([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("CSV file is required.");

            string tableName = Path.GetFileNameWithoutExtension(file.FileName);

            string result = await _csvService.ProcessAsync(file, tableName);
            return Ok(new { message = result });
        }
    }
}
