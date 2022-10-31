namespace WebApp.Domain;

// Generate crud pages
// dotnet aspnet-codegenerator controller -name CaesarsController -actions -m Caesar -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

public class Caesars
{
    public int Id { get; set; }
    
    public int ShiftAmount { get; set; }
    public string Plaintext { get; set; } = default!;
    public string Ciphertext { get; set; } = default!;
}