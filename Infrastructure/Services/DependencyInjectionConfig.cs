using AspMvcSample.Application.Repositories;
using AspMvcSample.Domain.Entities;
using AspMvcSample.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using AspMvcSample.Application.CQRS;
using AspMvcSample.Application.CQRS.Interfaces;
using AspMvcSample.Application.CQRS.Commands;
using AspMvcSample.Application.CQRS.Handlers;
using AspMvcSample.Application.CQRS.Queries;
using AspMvcSample.Application.DTOs;

namespace AspMvcSample.Infrastructure.Services
{
    public static class DependencyInjectionConfig
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRepository<Employee>, Repository<Employee>>();
            services.AddScoped<IRepository<Department>, Repository<Department>>();
            services.AddScoped<IRepository<Attendance>, Repository<Attendance>>();

            // Register CQRS mediator and handlers
            services.AddScoped<IMediator, Mediator>();

            // Employee CQRS
            services.AddScoped<ICommandHandler<CreateEmployeeCommand>, CreateEmployeeCommandHandler>();
            services.AddScoped<IQueryHandler<GetEmployeeByIdQuery, EmployeeDto?>, GetEmployeeByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>, GetAllEmployeesQueryHandler>();

            // Attendance CQRS
            services.AddScoped<ICommandHandler<CreateAttendanceCommand>, CreateAttendanceCommandHandler>();
            services.AddScoped<IQueryHandler<GetAttendanceByEmployeeQuery, IEnumerable<AttendanceDto>>, GetAttendanceByEmployeeQueryHandler>();

            // Department CQRS
            services.AddScoped<ICommandHandler<CreateDepartmentCommand>, CreateDepartmentCommandHandler>();
            services.AddScoped<IQueryHandler<GetDepartmentsByCompanyQuery, IEnumerable<DepartmentDto>>, GetDepartmentsByCompanyQueryHandler>();

            // Register other repositories and handlers here as needed
        }
    }
}
