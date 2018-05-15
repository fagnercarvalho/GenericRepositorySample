using Microsoft.EntityFrameworkCore;

namespace GenericRepositorySample.Data
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GenericRepositorySample;Trusted_Connection=True;");
        }
    }
}
