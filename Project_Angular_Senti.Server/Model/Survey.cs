using System.ComponentModel.DataAnnotations;

namespace Project_Angular_Senti.Server.Model
{
    public class Survey
    {

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }



    }
}
