namespace FinalAPISession.Models
{
    public class Device
    {

        public int Id { get; set; }

        public string Model { get; set; }

        public int PatientId { get; set; }

        public Patient? Patient { get; set; }
    }
}
