using AspMvcSample.Infrastructure.Persistence;
using AspMvcSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;

namespace Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void CanAddAndRetrieveEmployee()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Employees.Add(new Employee { Id = 1, FirstName = "Test", LastName = "User", Email = "test@user.com" });
                context.SaveChanges();
            }

            using (var context = new AppDbContext(options))
            {
                var employee = context.Employees.FirstOrDefault(e => e.Id == 1);
                Assert.NotNull(employee);
                Assert.Equal("Test", employee!.FirstName);
                Assert.Equal("User", employee.LastName);
                Assert.Equal("test@user.com", employee.Email);
            }
        }
    }
}