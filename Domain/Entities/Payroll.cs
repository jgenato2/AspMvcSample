namespace AspMvcSample.Domain.Entities
{
    public class Payroll
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime PayDate { get; set; }
        public decimal Amount { get; set; }
        public string? Notes { get; set; }
    }
}
