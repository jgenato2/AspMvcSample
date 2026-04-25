namespace AspMvcSample.Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
        public int? CompanyId { get; set; }
        public string? DepartmentName { get; set; }
        public string? PositionTitle { get; set; }
        public string? CompanyName { get; set; }
    }
}
