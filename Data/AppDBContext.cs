using Microsoft.EntityFrameworkCore;
using BookEndsAPI.Models;

namespace BookEndsAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}