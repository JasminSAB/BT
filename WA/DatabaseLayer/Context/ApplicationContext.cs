using Microsoft.EntityFrameworkCore;
using WA.DatabaseLayer.Models;

namespace WA.DatabaseLayer.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<ContactInfo> ContactInformations { get; set; }
    }
}
