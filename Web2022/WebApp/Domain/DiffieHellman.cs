using System.ComponentModel.DataAnnotations;
using WebApp.Domain.Identity;

namespace WebApp.Domain;

public class DiffieHellman
{
    
    // Auto-detected primary key
    [Key]
    public int Id { get; set; }
    
    public long PublicKeyP { get; set; }
    public long PublicKeyG { get; set; }
    public long  PrivateKeyA { get; set; }
    public long  PrivateKeyB { get; set; }
    public long ComputedKeyX { get; set; }
    public long ComputedKeyY { get; set; }
    public long ComputedKeyX2 { get; set; }
    public long ComputedKeyY2 { get; set; }
    
    
    public string AppUserId { get; set; } = default!;
    public AppUser? AppUser { get; set; }
}