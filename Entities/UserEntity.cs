using System.ComponentModel.DataAnnotations;

namespace Company.Function.Entities
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }
}
