using FinalAPISession.Models;

namespace FinalAPISession.DTO
{
    public class ReturnDoctorDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string? phone { get; set; }

        //Nav
        public DepartmentInDoctor? Department { get; set; }
    }

    public class DepartmentInDoctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

    }
}
