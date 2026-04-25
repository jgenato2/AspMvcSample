namespace AspMvcSample.Domain.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime Date { get; set; }
        public bool Present { get; set; }
        public string? Remarks { get; set; }
    }
}
