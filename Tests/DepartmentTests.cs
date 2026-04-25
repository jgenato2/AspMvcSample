using AspMvcSample.Infrastructure.Persistence;
using AspMvcSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;

namespace Tests
{
    public class DepartmentTests
    {
        [Fact]
        public void CanAddAndRetrieveDepartment()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_Department")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Departments.Add(new Department { Id = 1, Name = "HR", CompanyId = 1 });
                context.SaveChanges();
            }

            using (var context = new AppDbContext(options))
            {
                var department = context.Departments.FirstOrDefault(d => d.Id == 1);
                Assert.NotNull(department);
                Assert.Equal("HR", department!.Name);
                Assert.Equal(1, department.CompanyId);
            }
        }
    }
}