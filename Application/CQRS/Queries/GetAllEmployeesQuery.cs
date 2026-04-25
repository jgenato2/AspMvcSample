using AspMvcSample.Application.CQRS.Interfaces;
using AspMvcSample.Application.DTOs;
using System.Collections.Generic;

namespace AspMvcSample.Application.CQRS.Queries
{
    public class GetAllEmployeesQuery : IQuery<IEnumerable<EmployeeDto>>
    {
    }
}