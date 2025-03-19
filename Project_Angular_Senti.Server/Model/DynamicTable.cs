using System.Collections.Generic;

namespace Project_Angular_Senti.Server.Model
{
    public class DynamicTable
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public List<DynamicRow> Rows { get; set; } = new List<DynamicRow>();
    }
}
