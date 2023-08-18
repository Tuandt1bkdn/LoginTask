using System.ComponentModel.DataAnnotations;

namespace LoginTask.Models
{
    public class CreateRequest
    {
        [Key]
        public int? UserId { get; set; }
        public string? Name { get; set; }
        [Required]
        public string? Birthday { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Passwordhash { get; set; }
    }
}
