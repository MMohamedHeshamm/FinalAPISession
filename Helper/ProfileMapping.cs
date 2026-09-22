using AutoMapper;
using FinalAPISession.DTO;
using FinalAPISession.Models;

namespace FinalAPISession.Helper
{
    public class ProfileMapping : Profile

    {

        public ProfileMapping() {

            //Department Post
            CreateMap<AddDepartmentDTO,Department>();

            //Doctor Post
            CreateMap<AddDoctorDTO,Doctor>();

            //Doctor Get BY ID 
            CreateMap<Doctor,ReturnDoctorDTO>();
            CreateMap<Department,DepartmentInDoctor>();

            //Patient Get ALL 
            CreateMap<Patient,ReturnPatientDTO>();
            CreateMap<Doctor,DoctorinpatientDTO>();
            CreateMap<Device,DeviceinpatientDTO>();

            //Patient   update,Add
            CreateMap<AddPatientDTO,Patient>();
            CreateMap<DeviceinAddpatient,Device>();


        } 
    }
}
