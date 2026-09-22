namespace FinalAPISession.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string? phone { get; set; }

        public int DepartmentId { get; set; }

        public ICollection<Patient>? patients { get; set; } = new List<Patient>();

        public Department? Department { get; set; }
    }
}
