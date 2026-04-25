using AspMvcSample.Application.CQRS.Interfaces;
using AspMvcSample.Application.CQRS.Queries;
using AspMvcSample.Application.DTOs;
using AspMvcSample.Application.Repositories;
using AspMvcSample.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AspMvcSample.Application.CQRS.Handlers
{
    public class GetAllEmployeesQueryHandler : IQueryHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IRepository<Employee> _employeeRepository;
        public GetAllEmployeesQueryHandler(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<EmployeeDto> Handle(GetAllEmployeesQuery query)
        {
            return _employeeRepository.GetAll().Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DepartmentId = e.DepartmentId,
                // Add other fields as needed
            });
        }
    }
}