using System;
using System.ComponentModel.DataAnnotations;

namespace BlogAPIDotnet.Dtos.Account;

public class RegisterDto
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}
