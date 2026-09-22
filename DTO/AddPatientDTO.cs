using FinalAPISession.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalAPISession.DTO
{
    public class AddPatientDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<int>? DoctorsID { get; set; } 

        public DeviceinAddpatient? Device { get; set; }
    }
   
    public class DeviceinAddpatient
    {
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }


    } 
}
