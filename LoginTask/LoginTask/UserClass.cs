using System.ComponentModel.DataAnnotations;

namespace LoginTask
{
    public class UserClass
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Birthday { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public string? UserName { get; set; }

        public string? Passwordhash { get; set; }
    }
}
