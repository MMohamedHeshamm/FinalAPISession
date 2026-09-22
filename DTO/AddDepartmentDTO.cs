using FinalAPISession.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalAPISession.DTO
{
    public class AddDepartmentDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string? Description { get; set; }


    }
}
