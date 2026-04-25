namespace AspMvcSample.Domain.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
