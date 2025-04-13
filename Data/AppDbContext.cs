using Microsoft.EntityFrameworkCore;
using CRUD_API.Models;
namespace CRUD_API.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    public DbSet<User> Users { get; set; }

}
