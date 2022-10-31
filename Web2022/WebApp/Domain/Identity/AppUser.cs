using Microsoft.AspNetCore.Identity;
 
 namespace WebApp.Domain.Identity;
 
 public class AppUser : IdentityUser
 {
     public ICollection<Caesar> Caesars { get; set;  } = default!;
 }