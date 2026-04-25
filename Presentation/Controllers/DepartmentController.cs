using AspMvcSample.Application.CQRS;
using AspMvcSample.Application.CQRS.Commands;
using AspMvcSample.Application.CQRS.Queries;
using AspMvcSample.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AspMvcSample.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index(int? companyId)
        {
            int cid = companyId ?? 1;
            var departments = _mediator.Query<GetDepartmentsByCompanyQuery, IEnumerable<DepartmentDto>>(
                new GetDepartmentsByCompanyQuery(cid));
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentDto dto)
        {
            var cmd = new CreateDepartmentCommand
            {
                Name = dto.Name,
                CompanyId = dto.CompanyId ?? 0
            };
            _mediator.Send(cmd);
            return RedirectToAction("Index", new { companyId = dto.CompanyId });
        }
    }
}