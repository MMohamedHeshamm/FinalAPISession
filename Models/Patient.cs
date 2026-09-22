namespace FinalAPISession.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<Doctor>? Doctors { get; set; } = new HashSet<Doctor>();

        public Device? Device { get; set; }
    }
}
