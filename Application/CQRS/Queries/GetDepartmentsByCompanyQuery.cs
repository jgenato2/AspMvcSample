using AspMvcSample.Application.CQRS.Interfaces;
using AspMvcSample.Application.DTOs;

namespace AspMvcSample.Application.CQRS.Queries
{
    public class GetDepartmentsByCompanyQuery : IQuery<IEnumerable<DepartmentDto>>
    {
        public int CompanyId { get; set; }
        public GetDepartmentsByCompanyQuery(int companyId) { CompanyId = companyId; }
    }
}