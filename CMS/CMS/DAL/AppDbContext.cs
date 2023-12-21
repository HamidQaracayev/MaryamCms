using CMS.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Content> content { get; set; }
    }
}
