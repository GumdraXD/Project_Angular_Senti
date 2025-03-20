using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Project_Angular_Senti.Server.Model;
using System.Text;

namespace Project_Angular_Senti.Server.Data
{
    public class CsvService : IcsvService
    {
        private readonly ApplicationDbContext _context;

        public CsvService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> ProcessAsync(IFormFile file, string tableName)
        {
            if (file == null || file.Length == 0)
                return "Invalid file.";

            using var reader = new StreamReader(file.OpenReadStream());
            var headerLine = await reader.ReadLineAsync();
            if (string.IsNullOrEmpty(headerLine))
                return "Empty CSV file.";

            var headers = headerLine.Split(',').Select(h => h.Trim()).ToArray();

            var existingTable = _context.DynamicTables.FirstOrDefault(t => t.TableName == tableName);

            if (existingTable == null)
            {
                existingTable = new DynamicTable { TableName = tableName };
                _context.DynamicTables.Add(existingTable);
                await _context.SaveChangesAsync();
            }

            var rowsToInsert = new List<DynamicRow>();

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                var values = ParseCsvLine(line);

                values = values.Select(v => string.IsNullOrEmpty(v) ? "N/A" : v).ToArray();

                if (values.Length != headers.Length)
                {
                    continue;
                }

                var processedValues = values.Select(v => string.IsNullOrWhiteSpace(v) ? null: v.Trim()).ToArray();

                var row = new DynamicRow
                {
                    TableId = existingTable.Id,
                    Values = string.Join("|", processedValues)
                };

                rowsToInsert.Add(row);

                if (rowsToInsert.Count >= 100)
                {
                    _context.DynamicRows.AddRange(rowsToInsert);
                    await _context.SaveChangesAsync();
                    rowsToInsert.Clear();
                }
            }

            if (rowsToInsert.Any())
            {
                _context.DynamicRows.AddRange(rowsToInsert);
                await _context.SaveChangesAsync();
            }

            return "CSV file processed successfully.";
        }

        private string[] ParseCsvLine(string line)
        {
            var values = new List<string>();
            var currentValue = new StringBuilder();
            var insideQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '"')
                {
                    // Toggle the insideQuotes flag when encountering quotes
                    if (insideQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        // Handle escaped quote ("" inside quoted text)
                        currentValue.Append('"');
                        i++; // Skip next quote
                    }
                    else
                    {
                        insideQuotes = !insideQuotes; // Toggle state when encountering a quote
                    }
                }
                else if (currentChar == ',' && !insideQuotes)
                {
                    // Comma outside quotes is a separator
                    values.Add(currentValue.ToString());
                    currentValue.Clear();
                }
                else
                {
                    currentValue.Append(currentChar); // Append non-comma, non-quote characters
                }
            }

            // Add the last value (the last column)
            values.Add(currentValue.ToString());

            return values.ToArray();
        }
    }
}
