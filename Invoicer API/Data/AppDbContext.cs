using Invoicer_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoicer_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {}

        public DbSet<Invoice> Invoices
                                    => Set<Invoice>();
        public DbSet<InvoiceRow> InvoiceRows
                                    => Set<InvoiceRow>();
        public DbSet<User> Users
                                => Set<User>();


    }
}
