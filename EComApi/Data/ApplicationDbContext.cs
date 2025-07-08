using EComApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EComApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
    }
}
