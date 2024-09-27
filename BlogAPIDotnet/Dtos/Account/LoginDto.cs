using System;
using System.ComponentModel.DataAnnotations;

namespace BlogAPIDotnet.Dtos.Account;

public class LoginDto
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
}
