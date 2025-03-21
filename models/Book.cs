using System.ComponentModel.DataAnnotations;

namespace BookEndsAPI.Models
{
    public class Book{
        [Key]
        public int BookID {get; set;}

        [Required]
        public string Title {get; set;}
        
        [Required]
        public string Author {get; set;}
        
        public string Genre {get; set;}
        
        [Range(1,5)]
        public int Rating {get; set;}

        public DateTime DateFinished {get; set;}

        public string Notes {get; set;}
    }
}