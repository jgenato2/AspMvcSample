using AspMvcSample.Application.CQRS.Interfaces;
using AspMvcSample.Application.CQRS.Commands;
using AspMvcSample.Application.Repositories;
using AspMvcSample.Domain.Entities;

namespace AspMvcSample.Application.CQRS.Handlers
{
    public class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
    {
        private readonly IRepository<Employee> _employeeRepository;
        public CreateEmployeeCommandHandler(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void Handle(CreateEmployeeCommand command)
        {
            var employee = new Employee
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                DateOfBirth = command.DateOfBirth,
                DepartmentId = command.DepartmentId,
                PositionId = command.PositionId,
                CompanyId = command.CompanyId
            };
            _employeeRepository.Add(employee);
        }
    }
}