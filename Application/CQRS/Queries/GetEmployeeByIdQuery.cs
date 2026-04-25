using AspMvcSample.Application.CQRS.Interfaces;
using AspMvcSample.Application.DTOs;

namespace AspMvcSample.Application.CQRS.Queries
{
    public class GetEmployeeByIdQuery : IQuery<EmployeeDto?>
    {
        public int Id { get; set; }
        public GetEmployeeByIdQuery(int id) { Id = id; }
    }
}