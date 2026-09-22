using AutoMapper;
using FinalAPISession.DTO;
using FinalAPISession.Models;
using FinalAPISession.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPISession.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGeneric<Doctor> _Generic;
        private readonly IGeneric<Department> _department ;
        private readonly DoctorRepo _repo;

        public DoctorController(IMapper mapper, IGeneric<Doctor> generic, IGeneric<Department> department, DoctorRepo repo)
        {
            _Generic = generic;
            _mapper = mapper;
            _department = department;
            _repo = repo;
        }

        //Add Doctor 
        [HttpPost]
        public async Task<ActionResult> AddDoctor(AddDoctorDTO x)
        {
            //validation
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //validation Department ID
            var departmentResult = await _department.GetBYID(x.DepartmentId);
            if (departmentResult == null)
                return NotFound();


            var result = _mapper.Map<Doctor>(x);
            await _Generic.Add(result);
            return Ok();
        }

        //Get Doctor 
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnDoctorDTO>> GetDoctor (int id)
        {
            var result = await _repo.GetBYID(id);
            if (result == null)
                return NotFound();


            var resultDto = _mapper.Map<ReturnDoctorDTO>(result);
            return Ok(resultDto);

        } 


    }
}
