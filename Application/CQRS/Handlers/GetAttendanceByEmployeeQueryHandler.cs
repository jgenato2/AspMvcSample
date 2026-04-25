using AspMvcSample.Application.CQRS.Interfaces;
using AspMvcSample.Application.CQRS.Queries;
using AspMvcSample.Application.DTOs;
using AspMvcSample.Application.Repositories;
using AspMvcSample.Domain.Entities;

namespace AspMvcSample.Application.CQRS.Handlers
{
    public class GetAttendanceByEmployeeQueryHandler : IQueryHandler<GetAttendanceByEmployeeQuery, IEnumerable<AttendanceDto>>
    {
        private readonly IRepository<Attendance> _attendanceRepository;
        public GetAttendanceByEmployeeQueryHandler(IRepository<Attendance> attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }
        public IEnumerable<AttendanceDto> Handle(GetAttendanceByEmployeeQuery query)
        {
            return _attendanceRepository.GetAll()
                .Where(a => a.EmployeeId == query.EmployeeId)
                .Select(a => new AttendanceDto
                {
                    Id = a.Id,
                    EmployeeId = a.EmployeeId,
                    EmployeeName = a.Employee?.FirstName + " " + a.Employee?.LastName,
                    Date = a.Date,
                    Present = a.Present,
                    Remarks = a.Remarks
                });
        }
    }
}