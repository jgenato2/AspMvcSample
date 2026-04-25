using AspMvcSample.Application.CQRS;
using AspMvcSample.Application.CQRS.Commands;
using AspMvcSample.Application.CQRS.Queries;
using AspMvcSample.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AspMvcSample.Presentation.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IMediator _mediator;
        public AttendanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index(int employeeId)
        {
            var attendance = _mediator.Query<GetAttendanceByEmployeeQuery, IEnumerable<AttendanceDto>>(
                new GetAttendanceByEmployeeQuery(employeeId));
            return View(attendance);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AttendanceDto dto)
        {
            var cmd = new CreateAttendanceCommand
            {
                EmployeeId = dto.EmployeeId ?? 0,
                Date = dto.Date,
                Present = dto.Present,
                Remarks = dto.Remarks
            };
            _mediator.Send(cmd);
            return RedirectToAction("Index", new { employeeId = dto.EmployeeId });
        }
    }
}