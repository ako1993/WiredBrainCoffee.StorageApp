using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.StorageApp.Entites;

namespace WiredBrainCoffee.StorageApp.Data
{
    public class StorageAppDBContext: DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Organization> Organizations => Set<Organization>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
