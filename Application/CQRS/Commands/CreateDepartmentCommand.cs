using AspMvcSample.Application.CQRS.Interfaces;

namespace AspMvcSample.Application.CQRS.Commands
{
    public class CreateDepartmentCommand : ICommand
    {
        public string? Name { get; set; }
        public int CompanyId { get; set; }
    }
}