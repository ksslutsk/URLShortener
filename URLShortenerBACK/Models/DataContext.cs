using Microsoft.EntityFrameworkCore;
using URLShortenerBACK.Models;

namespace URLShortenerBACK.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ): base(options)
        {   }
        public DbSet<URL> URLs { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
