using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Domain;

// Generate crud pages
// dotnet aspnet-codegenerator controller -name CaesarsController -actions -m Caesars -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

public class Caesar
{
    // Auto-detected primary key
    [Key]
    public int Id { get; set; }
    
    public int ShiftAmount { get; set; }
    public string Plaintext { get; set; } = default!;
    public string Ciphertext { get; set; } = default!;
    
    
    public string IdentityUserId { get; set; } = default!;
    public IdentityUser? IdentityUser { get; set; }
}