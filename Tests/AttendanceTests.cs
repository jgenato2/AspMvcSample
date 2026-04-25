using AspMvcSample.Infrastructure.Persistence;
using AspMvcSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;

namespace Tests
{
    public class AttendanceTests
    {
        [Fact]
        public void CanAddAndRetrieveAttendance()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_Attendance")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Attendances.Add(new Attendance { Id = 1, EmployeeId = 1, Date = System.DateTime.Today, Present = true, Remarks = "On time" });
                context.SaveChanges();
            }

            using (var context = new AppDbContext(options))
            {
                var attendance = context.Attendances.FirstOrDefault(a => a.Id == 1);
                Assert.NotNull(attendance);
                Assert.Equal(1, attendance!.EmployeeId);
                Assert.True(attendance.Present);
                Assert.Equal("On time", attendance.Remarks);
            }
        }
    }
}