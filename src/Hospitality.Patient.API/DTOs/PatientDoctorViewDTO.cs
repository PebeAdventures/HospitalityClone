namespace Hospitality.Patient.API.DTOs
{
    public class PatientDoctorViewDTO
    {
        [Required]
        public string PatientName { get; set; }

        [Required]
        public string PatientSurname { get; set; }
        
        [Required]
        public string PatientPesel { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
    }
}