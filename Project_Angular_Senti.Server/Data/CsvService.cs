using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Project_Angular_Senti.Server.Model;

namespace Project_Angular_Senti.Server.Data
{
    public class CsvService : IcsvService
    {
        private readonly ApplicationDbContext _context;

        public CsvService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> ProcessAsync(IFormFile file, string identifierColumn)
        {
            if (file == null || file.Length == 0)
                return "Invalid file.";

            using var reader = new StreamReader(file.OpenReadStream());
            var headerLine = await reader.ReadLineAsync();
            if (string.IsNullOrEmpty(headerLine))
                return "Empty CSV file.";

            var headers = headerLine.Split(',').Select(h => h.Trim()).ToArray();
            if (!headers.Contains(identifierColumn))
                return "Identifier column not found in CSV.";

            string tableName = Regex.Replace(identifierColumn, ".{3}$", "");

            var existingTable = _context.DynamicTables.FirstOrDefault(t => t.TableName == tableName);

            if (existingTable == null)
            {
                existingTable = new DynamicTable { TableName = tableName };
                _context.DynamicTables.Add(existingTable);
                await _context.SaveChangesAsync();
            }

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                var values = line.Split(',');

                var row = new DynamicRow
                {
                    TableId = existingTable.Id,
                    Values = string.Join("|", values)
                };

                _context.DynamicRows.Add(row);
            }

            await _context.SaveChangesAsync();
            return "CSV file processed successfully.";
        }
    }
}
