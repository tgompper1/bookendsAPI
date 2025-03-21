using System.ComponentModel.DataAnnotations;

namespace BookEndsAPI.Models
{
    public class User{
        [Key]
        public int UserID {get; set;}

        [Required]
        public string email {get; set;}
        
        [Required]
        public string PasswordHash {get; set;}
    }
}