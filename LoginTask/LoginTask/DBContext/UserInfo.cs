using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LoginTask.DBContext;

public partial class UserInfo
{
    [Key]
    public int UserId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Birthday { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public string UserName { get; set; }

    public string PasswordHash { get; set; }
    
}
