using Microsoft.EntityFrameworkCore;
using AspMvcSample.Domain.Entities;

namespace AspMvcSample.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        // Add other DbSets as needed
    }
}