using ContactList.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
