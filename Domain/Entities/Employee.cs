namespace AspMvcSample.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int PositionId { get; set; }
        public Position? Position { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<LeaveRequest>? LeaveRequests { get; set; }
        public ICollection<Payroll>? Payrolls { get; set; }
        public ICollection<EmployeeRole>? EmployeeRoles { get; set; }
    }
}
