namespace Hospitality.Patient.API.DTOs
{
    public record PatentDoctorViewDTO
    {
        public int PatientId { get; init; }

        [Required]
        public string PatientName { get; init; }

        [Required]
        public string PatientSurname { get; init; }
        
        [Required]
        public string PatientPesel { get; init; }
        
        [Required]
        public DateTime BirthDate { get; init; }
    }
}