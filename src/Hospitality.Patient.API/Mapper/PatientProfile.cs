namespace Hospitality.Patient.API.Mapper
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<HospitalPatient, PatientDoctorViewDTO>();
            CreateMap<HospitalPatient, PatientReceptionistViewDTO>();
        }
    }
}
