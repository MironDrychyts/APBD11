using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models;

public class User
{
    [Key]
    [Required]
    public int IdUser { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public string Salt { get; set; }
    
    public string RefreshToken { get; set; }
    
    public DateTime? RefreshTokenExp { get; set; }
}