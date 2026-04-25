using AspMvcSample.Application.CQRS.Interfaces;
using AspMvcSample.Application.CQRS.Queries;
using AspMvcSample.Application.DTOs;
using AspMvcSample.Application.Repositories;
using AspMvcSample.Domain.Entities;

namespace AspMvcSample.Application.CQRS.Handlers
{
    public class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, EmployeeDto?>
    {
        private readonly IRepository<Employee> _employeeRepository;
        public GetEmployeeByIdQueryHandler(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public EmployeeDto? Handle(GetEmployeeByIdQuery query)
        {
            var employee = _employeeRepository.GetById(query.Id);
            if (employee == null) return null;
            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                DepartmentId = employee.DepartmentId,
                PositionId = employee.PositionId,
                CompanyId = employee.CompanyId
            };
        }
    }
}