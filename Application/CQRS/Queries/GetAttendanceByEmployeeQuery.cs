using AspMvcSample.Application.CQRS.Interfaces;
using AspMvcSample.Application.DTOs;

namespace AspMvcSample.Application.CQRS.Queries
{
    public class GetAttendanceByEmployeeQuery : IQuery<IEnumerable<AttendanceDto>>
    {
        public int EmployeeId { get; set; }
        public GetAttendanceByEmployeeQuery(int employeeId) { EmployeeId = employeeId; }
    }
}