using AspMvcSample.Application.CQRS.Interfaces;
using AspMvcSample.Application.CQRS.Commands;
using AspMvcSample.Application.Repositories;
using AspMvcSample.Domain.Entities;

namespace AspMvcSample.Application.CQRS.Handlers
{
    public class CreateAttendanceCommandHandler : ICommandHandler<CreateAttendanceCommand>
    {
        private readonly IRepository<Attendance> _attendanceRepository;
        public CreateAttendanceCommandHandler(IRepository<Attendance> attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }
        public void Handle(CreateAttendanceCommand command)
        {
            var attendance = new Attendance
            {
                EmployeeId = command.EmployeeId,
                Date = command.Date,
                Present = command.Present,
                Remarks = command.Remarks ?? string.Empty
            };
            _attendanceRepository.Add(attendance);
        }
    }
}