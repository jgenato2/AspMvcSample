using AspMvcSample.Application.CQRS;
using AspMvcSample.Application.CQRS.Commands;
using AspMvcSample.Application.CQRS.Queries;
using AspMvcSample.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AspMvcSample.Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            // For demo, fetch all employees (assume query handler exists)
            var employees = _mediator.Query<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>(new GetAllEmployeesQuery());
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employee = _mediator.Query<GetEmployeeByIdQuery, EmployeeDto?>(new GetEmployeeByIdQuery(id));
            if (employee == null) return NotFound();
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto dto)
        {
            var cmd = new CreateEmployeeCommand
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                // Add other fields as needed
            };
            _mediator.Send(cmd);
            return RedirectToAction("Index");
        }
    }
}