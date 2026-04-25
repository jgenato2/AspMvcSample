using System;

namespace AspMvcSample.Application.DTOs
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; } = null;
        public string? EmployeeName { get; set; } = null;
        public DateTime Date { get; set; }
        public bool Present { get; set; }
        public string? Remarks { get; set; } = null;
    }
}
