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
    public string PlaintextBytes { get; set; } = default!;
    public long PrimeP { get; set; }
    public long PrimeQ { get; set; }
    public long PublicKeyN { get; set; }
    public long Modulus { get; set; }
    public long Exponent { get; set; }
    public string EncryptedBytes { get; set; } = default!;
    
    public string AppUserId { get; set; } = default!;
    public AppUser? AppUser { get; set; }
}