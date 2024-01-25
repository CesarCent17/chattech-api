using chattech_auth.Models;
using Microsoft.EntityFrameworkCore;

namespace chattech_auth.DataSource
{
    public class ChattechDbContext : DbContext
    {
        public ChattechDbContext(DbContextOptions<ChattechDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
