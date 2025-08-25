using System.Data.Entity;

namespace twentysecassign.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("DefaultConnection") { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
