using AspMvcSample.Application.CQRS.Interfaces;

namespace AspMvcSample.Application.CQRS.Commands
{
    public class CreateEmployeeCommand : ICommand
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int CompanyId { get; set; }
    }
}