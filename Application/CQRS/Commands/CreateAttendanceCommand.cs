using AspMvcSample.Application.CQRS.Interfaces;

namespace AspMvcSample.Application.CQRS.Commands
{
    public class CreateAttendanceCommand : ICommand
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public bool Present { get; set; }
        public string? Remarks { get; set; }
    }
}