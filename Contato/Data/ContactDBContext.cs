using Contato.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Contato.Data
{
    public class ContactDBContext : DbContext
    {
        public ContactDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Contact> Contatos { get; set; }

    }
}
