using FinalAPISession.Models;

namespace FinalAPISession.DTO
{
    public class ReturnPatientDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<DoctorinpatientDTO>? Doctors { get; set; } = new HashSet<DoctorinpatientDTO>();

        public DeviceinpatientDTO? Device { get; set; }
    }

    public class DoctorinpatientDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string? phone { get; set; }

        public int DepartmentId { get; set; }

    }
    
    public class DeviceinpatientDTO
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public int PatientId { get; set; }

    }

}

