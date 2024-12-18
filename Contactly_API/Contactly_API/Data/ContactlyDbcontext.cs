using Contactly_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contactly_API.Data
{
    public class ContactlyDbcontext : DbContext
    {
        public ContactlyDbcontext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Contact> Contacts { get; set; }
    }
}
