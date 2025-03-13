using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Project_Angular_Senti.Server.Model;
using Project_Angular_Senti.Server.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project_Angular_Senti.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        public readonly SurveyContext _context;

        public SurveyController(SurveyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> saveSurvey([FromBody] SurveyRequest surveyRequest)
        {
            if (surveyRequest == null) return BadRequest("Invalid survey data.");
            if (!ModelState.IsValid) {
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"Key: {error.Key}, Error: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}");
                }
                return BadRequest(ModelState); 
            }

            var survey = new Survey
            {
                Respondent = surveyRequest.Respondent,
                SurveyResponses = surveyRequest.SurveyResponses.Select(r => new SurveyResponse
                {
                    Question = r.Question,
                    Response = r.Response,
                }).ToList()
            };

            _context.Survey.Add(survey);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Survey submitted successfully!", surveyId = survey.Id });
            //return CreatedAtAction(nameof(GetSurveyById), new { id = survey.Id }, survey);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Survey>>> getSurvey()
        {
            return await _context.Survey.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Survey>> GetSurveyById(int id)
        {
            var survey = await _context.Survey.FindAsync(id);
            if (survey == null) return NotFound();
            return survey;
        }
    }
}
