using Microsoft.EntityFrameworkCore;

namespace Net6WebAPIEF.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Incident> Incidents { get; set; }

    }
}
