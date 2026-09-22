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
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PatientRepo _patientRepo;
        private readonly DoctorRepo _doctorRepo;
        public PatientController(IMapper mapper, PatientRepo patientRepo, DoctorRepo doctorRepo) {
            _mapper = mapper;
            _patientRepo = patientRepo;
            _doctorRepo = doctorRepo;
        }

        //Get All Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnPatientDTO>>> GetPatients()
        {
            var result = await _patientRepo.GetAll();
            var finalResult = _mapper.Map<IEnumerable<ReturnPatientDTO>>(result);
            return Ok(finalResult);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var result = await _patientRepo.Delete(id);

            if (result == false)
                return NotFound();

            return Ok();
        }

        //Add Patient
        [HttpPost]
        public async Task<ActionResult> AddPatient(AddPatientDTO addPatientDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var finalpatient = _mapper.Map<Patient>(addPatientDTO);

            //check doctors ID 
            foreach (int id in addPatientDTO.DoctorsID)
            {
                var doctorResult = await _doctorRepo.GetBYID(id);
                if (doctorResult == null)
                    return NotFound();

                finalpatient.Doctors.Add(doctorResult);

            }

            await _patientRepo.Add(finalpatient);
            return Ok();
        }



        //update patient
        [HttpPut("{id}")]
        public async Task <ActionResult> UpdatePatient (AddPatientDTO updatePatientDTO, int id)
        {
            var patientdata = await _patientRepo.GetBYID(id);

            if (patientdata == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            //update patient data
            patientdata.Email = updatePatientDTO.Email;
            patientdata.Name = updatePatientDTO.Name;

             
            //update device data 
            if(updatePatientDTO.Device != null)
            {
                if (patientdata.Device == null)
                    patientdata.Device = new Device();

                patientdata.Device.Model = updatePatientDTO.Device.Model;

            }
            //update Doctor list data
            if(updatePatientDTO.DoctorsID != null)
            {
                patientdata.Doctors.Clear();

                foreach(var doctorid in updatePatientDTO.DoctorsID)
                {
                    var _Doctor = await _doctorRepo.GetBYID(doctorid);

                    if (_Doctor == null)
                        return NotFound();

                    patientdata.Doctors.Add(_Doctor);
                }
            }
            

            await _patientRepo.Update(patientdata);
            return Ok();
        }
    }
}
