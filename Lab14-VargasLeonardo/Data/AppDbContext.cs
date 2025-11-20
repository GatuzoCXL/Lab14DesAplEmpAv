using Microsoft.EntityFrameworkCore;
using Lab14_VargasLeonardo.Models;

namespace Lab14_VargasLeonardo.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
