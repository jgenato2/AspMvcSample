using AspMvcSample.Application.CQRS.Interfaces;
using AspMvcSample.Application.CQRS.Commands;
using AspMvcSample.Application.Repositories;
using AspMvcSample.Domain.Entities;

namespace AspMvcSample.Application.CQRS.Handlers
{
    public class CreateDepartmentCommandHandler : ICommandHandler<CreateDepartmentCommand>
    {
        private readonly IRepository<Department> _departmentRepository;
        public CreateDepartmentCommandHandler(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public void Handle(CreateDepartmentCommand command)
        {
            var department = new Department
            {
                Name = command.Name,
                CompanyId = command.CompanyId
            };
            _departmentRepository.Add(department);
        }
    }
}