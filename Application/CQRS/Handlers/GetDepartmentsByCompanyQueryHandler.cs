using AspMvcSample.Application.CQRS.Interfaces;
using AspMvcSample.Application.CQRS.Queries;
using AspMvcSample.Application.DTOs;
using AspMvcSample.Application.Repositories;
using AspMvcSample.Domain.Entities;

namespace AspMvcSample.Application.CQRS.Handlers
{
    public class GetDepartmentsByCompanyQueryHandler : IQueryHandler<GetDepartmentsByCompanyQuery, IEnumerable<DepartmentDto>>
    {
        private readonly IRepository<Department> _departmentRepository;
        public GetDepartmentsByCompanyQueryHandler(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IEnumerable<DepartmentDto> Handle(GetDepartmentsByCompanyQuery query)
        {
            return _departmentRepository.GetAll()
                .Where(d => d.CompanyId == query.CompanyId)
                .Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    CompanyId = d.CompanyId
                });
        }
    }
}