using chattech_users.Models;
using dotenv.net;
using Microsoft.EntityFrameworkCore;

namespace chattech_users.DataSource
{
    public class ChattechDbContext : DbContext
    {
        public ChattechDbContext(DbContextOptions<ChattechDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
