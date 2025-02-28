using System.ComponentModel.DataAnnotations.Schema;
namespace Project_Angular_Senti.Server.Model
{
    [Table ("Users")]
    public class User
    {

        public Guid Id { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
    }
}
