using System.Collections;
using System.ComponentModel.DataAnnotations;
using WebApp.Domain.Identity;

namespace WebApp.Domain;

public class RSA
{
    // Auto-detected primary key
    [Key]
    public int Id { get; set; }

    public string Plaintext { get; set; } = default!;
    public byte[] PlaintextBytes { get; set; } = default!;
    public int PrimeP { get; set; }
    public int PrimeQ { get; set; }
    public int Modulus { get; set; }
    public int Exponent { get; set; }
    public string EncryptedBytes { get; set; } = default!;
    
    public string AppUserId { get; set; } = default!;
    public AppUser? AppUser { get; set; }
}