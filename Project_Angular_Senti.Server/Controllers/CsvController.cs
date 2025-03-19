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
        public async Task<IActionResult> UploadCsv([FromForm] CsvUploadModel model)
        {
            if (model.File == null || model.File.Length == 0)
                return BadRequest("CSV file is required.");

            string result = await _csvService.ProcessAsync(model.File, model.IdentifierColum);
            return Ok(new { message = result });
        }
    }
}
