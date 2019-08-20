using BlushMe.Model;
using Microsoft.EntityFrameworkCore;

namespace BlushMe.Data
{
    public class BlushDbContext : DbContext
    {
        public BlushDbContext(DbContextOptions<BlushDbContext> options)
            : base(options)
        { }
        
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }


    }
}