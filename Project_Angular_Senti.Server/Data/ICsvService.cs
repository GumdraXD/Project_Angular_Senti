using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace Project_Angular_Senti.Server.Data
{
    public interface IcsvService
    {
        Task<string> ProcessAsync(IFormFile file, string identifierColumn);
    }
}
