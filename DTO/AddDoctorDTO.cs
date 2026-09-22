using FinalAPISession.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalAPISession.DTO
{
    public class AddDoctorDTO
    {

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? phone { get; set; }

        public int DepartmentId { get; set; }


    }
}
