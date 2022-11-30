using System.ComponentModel.DataAnnotations;
using WebApp.Domain.Identity;

namespace WebApp.Domain;

public class DiffieHellman
{
    
    // Auto-detected primary key
    [Key]
    public int Id { get; set; }
    
    public int PublicKeyP { get; set; }
    public int PublicKeyG { get; set; }
    public int  PrivateKeyA { get; set; }
    public int  PrivateKeyB { get; set; }
    public int ComputedKeyX { get; set; }
    public int ComputedKeyY { get; set; }
    
    
    public string AppUserId { get; set; } = default!;
    public AppUser? AppUser { get; set; }
}