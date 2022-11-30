using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Domain;
using WebApp.Domain.Identity;

namespace WebApp.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Caesar> Caesars { get; set; } = default!;

    public DbSet<WebApp.Domain.DiffieHellman>? DiffieHellman { get; set; }
}