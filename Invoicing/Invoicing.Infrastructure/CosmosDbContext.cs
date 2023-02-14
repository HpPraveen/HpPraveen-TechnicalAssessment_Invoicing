using Invoicing.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Invoicing.Infrastructure
{
    public class CosmosDbContext : DbContext
    {
        public DbSet<Invoice>? Invoices { get; set; }
        private readonly IConfiguration _configuration;

        public CosmosDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var endPointUri = _configuration["CosmosDb:EndPointUri"];
            var accountKey = _configuration["CosmosDb:AccountKey"];
            var db = _configuration["CosmosDb:DB"];

            optionsBuilder.UseCosmos(endPointUri, accountKey, db);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuring Invoices
            modelBuilder.Entity<Invoice>()
                .ToContainer("Invoices") // ToContainer
                .HasPartitionKey(e => e.Id); // Partition Key  

            modelBuilder.Entity<Invoice>().OwnsMany(p => p.InvoiceLines);
        }
    }

}
