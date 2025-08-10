using api_explorer_hub.Model;
using Microsoft.EntityFrameworkCore;

namespace api_explorer_hub.DataContext
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options)
            :base(options)
        {
            
        }
    }
}
