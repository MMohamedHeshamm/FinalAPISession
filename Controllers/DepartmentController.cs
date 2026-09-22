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
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper _mapper ;
        private readonly IGeneric<Department> _Generic;

        public DepartmentController (IMapper mapper, IGeneric<Department> generic)
        {
            _Generic = generic;
            _mapper = mapper;   
        }

        //Add Department
        [HttpPost]
        public async Task<ActionResult> AddDepartment(AddDepartmentDTO x)
        {
            //validation
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _mapper.Map<Department>(x);
            await _Generic.Add(result);
            return Ok();
        }

    }
}
